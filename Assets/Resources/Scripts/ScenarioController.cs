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
    public void DisplayStartText ()
    {
        SetButtonsEnable(ScenarioMode.Story);
        int getIndex = playerIndex == 1 ? 0 : 1;
        text.GetComponent<Text>().text = currentScenario.playerScenarios[playerIndex].startText.Replace("[message]", responses[getIndex]);
    }

    // Display choices
    public void DisplayChoices ()
    { 
        SetButtonsEnable(ScenarioMode.Choice);
        for (int i = 0; i < buttons.childCount; ++i)
        {
            buttons.GetChild(i).Find("Text").GetComponent<Text>().text = currentScenario.playerScenarios[playerIndex].choice.choices[i];
        }
    }

    // Display end text
    public void DisplayEndText ()
    {
        SetButtonsEnable(ScenarioMode.Story);
        string key = "";
        foreach (PlayerScenario p in currentScenario.playerScenarios)
        {
            key += p.choice.decision;
        }
        text.GetComponent<Text>().text = currentScenario.playerScenarios[playerIndex].endText[key];
    }
    
    // Display response field
    public void DisplayResponseField ()
    {
        SetButtonsEnable(ScenarioMode.Respond);
        string key = "";
        foreach (PlayerScenario p in currentScenario.playerScenarios)
        {
            key += p.choice.decision;
        }
        responseBox.GetChild(0).GetComponent<Text>().text = currentScenario.playerScenarios[playerIndex].responseText[key];
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
        currentScenario.playerScenarios[playerIndex].choice.decision = value;
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
        for (int i = 0; i < currentScenario.playerScenarios.Count; ++i)
        {
            moveOn = false;
            playerIndex = i;
            DisplayStartText();
            while (!moveOn)
            {
                yield return new WaitForEndOfFrame();
            }
        }
        for (int i = 0; i < currentScenario.playerScenarios.Count; ++i)
        {
            moveOn = false;
            playerIndex = i;
            DisplayChoices();
            while (!moveOn)
            {
                yield return new WaitForEndOfFrame();
            }
        }
        for (int i = 0; i < currentScenario.playerScenarios.Count; ++i)
        {
            moveOn = false;
            playerIndex = i;
            DisplayEndText();
            while (!moveOn)
            {
                yield return new WaitForEndOfFrame();
            }
        }
        for (int i = 0; i < currentScenario.playerScenarios.Count; ++i)
        {
            moveOn = false;
            playerIndex = i;
            DisplayResponseField();
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