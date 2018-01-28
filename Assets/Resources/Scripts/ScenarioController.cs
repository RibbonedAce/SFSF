using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioController : MonoBehaviour {
    public static ScenarioController instance;
    public List<Scenario> scenarios;
    public List<string> responses;
    public Scenario currentScenario;
    public Transform text;
    public Transform buttons;
    public Transform responseBox;
    private Choice currentChoice;
    private int playerIndex;
    private bool moveOn = false;
    private int scenarioIndex = -1;
    private bool finished = true;

    void Awake ()
    {
        scenarios = new List<Scenario>();
        foreach (TextAsset t in Resources.LoadAll<TextAsset>("Scenarios"))
        {
            scenarios.Add(new Scenario(t.text));
        }
        responses = new List<string>();
        responses.Add("");
        responses.Add("");
        text.GetComponent<Text>().text = "";
        SetButtonsEnable(ScenarioMode.Story);
    }

    // Update is called once per frame
    void Update ()
    {
        if (finished && scenarioIndex < scenarios.Count)
        {
            StartScenario(++scenarioIndex);
        }
    }

    // Start presenting a new scenario
    public void StartScenario (int scenarioIndex)
    {
        currentScenario = scenarios[scenarioIndex];
        StartCoroutine(PlayThroughScenario());
    }

    // Display starting text
    public void DisplayStartText (StartText st)
    {
        SetButtonsEnable(ScenarioMode.Story);
        int getIndex = st.index == 1 ? 0 : 1;
        text.GetComponent<Text>().text = st.text.Replace("[message]", responses[getIndex]);
    }

    // Display choices
    public void DisplayChoices (Choice c)
    { 
        SetButtonsEnable(ScenarioMode.Choice);
        for (int i = 0; i < c.choices.Count; ++i)
        {
            buttons.GetChild(i).Find("Text").GetComponent<Text>().text = c.choices[i];
        }
    }

    // Display end text
    public void DisplayEndText (EndText et)
    {
        SetButtonsEnable(ScenarioMode.Story);
        text.GetComponent<Text>().text = et.GetFromChoices();
    }
    
    // Display response field
    public void DisplayResponseField (Response r)
    {
        SetButtonsEnable(ScenarioMode.Respond);
        responseBox.GetChild(0).GetComponent<Text>().text = r.GetFromChoices();
    }

    // Respond to scenario
    public void Respond ()
    {
        responses[playerIndex] = responseBox.GetChild(1).GetComponent<InputField>().text;
        responseBox.GetChild(1).GetComponent<InputField>().text = "";
    }

    // Make decision for given player scenario
    public void MakeDecision (string value)
    {
        currentChoice.decision = value;
    }

    // Choose when to present next part
    public void Continue ()
    {
        moveOn = true;
    }

    // Going through the scnario
    public IEnumerator PlayThroughScenario ()
    {
        finished = false;
        foreach (StoryPart s in currentScenario.scenarioParts)
        {
            moveOn = false;
            playerIndex = s.index;
            if (s.GetType() == typeof(Choice))
            {
                currentChoice = (Choice)s;
                DisplayChoices((Choice)s);
            }
            else if (s.GetType() == typeof(Response))
            {
                DisplayResponseField((Response)s);
            }
            else if (s.GetType() == typeof(StartText))
            {
                DisplayStartText((StartText)s);
            }
            else if (s.GetType() == typeof(EndText))
            {
                DisplayEndText((EndText)s);
            }
            else
            {
                Debug.LogError("StoryPart type not valid!");
            }
            while (!moveOn)
            {
                yield return new WaitForEndOfFrame();
            }
        }
        text.GetComponent<Text>().text = "";
        SetButtonsEnable(ScenarioMode.Story);
        finished = true;
    }

    // Make the buttons visible or invisible
    private void SetButtonsEnable (ScenarioMode mode)
    {
        buttons.gameObject.SetActive(mode == ScenarioMode.Choice);
        text.gameObject.SetActive(mode == ScenarioMode.Story);
        responseBox.gameObject.SetActive(mode == ScenarioMode.Respond);
    }
}

public enum ScenarioMode
{
    Story,
    Choice,
    Respond
}