using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScenarioController : MonoBehaviour {
    public static ScenarioController instance;
    public List<Scenario> scenarios;
    public List<string> responses;
    public Scenario currentScenario;
    public Transform text;
    public Transform buttons;
    public Transform responseBox;
    public Text playerIndicator;
    public List<Color> playerColors;
    private Choice currentChoice;
    private int playerIndex;
    private bool moveOn = false;
    private int scenarioIndex = -1;
    private bool finished = true;
    private bool canStart = false;

    private AudioSource bgmSource;
    private AudioClip[] bgmClips;
    public Transform menu;
    private bool[] modeCheck;
    private ScenarioMode currentMode;

    void Awake ()
    {
        bgmSource = GetComponent<AudioSource>();
        bgmClips = Resources.LoadAll<AudioClip>("Audio/bgmSound");


        scenarios = new List<Scenario>();
        foreach (TextAsset t in Resources.LoadAll<TextAsset>("Scenarios"))
        {
            scenarios.Add(new Scenario(t.text));
        }
        responses = new List<string>();
        responses.Add("");
        responses.Add("");
        text.GetComponent<Text>().text = "";
        StartCoroutine(StartWithDelay(2));
    }

    // Update is called once per frame
    void Update ()
    {
        if (canStart && finished && ++scenarioIndex < scenarios.Count)
        {
            StartScenario(scenarioIndex);
        }
        if (scenarioIndex >= scenarios.Count)
        {
            SceneManager.LoadScene(0);
        }
    }

    // Start presenting a new scenario
    public void StartScenario (int scenarioIndex)
    {
        playSound(scenarioIndex);
        GameObject.Find("PlayerText").SetActive(true);
        currentScenario = scenarios[scenarioIndex];
        StartCoroutine(PlayThroughScenario());
    }

    // Display starting text
    public void DisplayStartText (StartText st)
    {
        SetButtonsEnable(ScenarioMode.Story);
        int getIndex = st.index == 1 ? 0 : 1;
        string fixedText = st.text.Replace("[message]", responses[getIndex]);
        text.GetComponent<Text>().color = playerColors[playerIndex];
        text.GetComponent<typer>().StartRoutines(fixedText);
    }

    // Display choices
    public void DisplayChoices (Choice c)
    {
        currentChoice = c;
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
        text.GetComponent<Text>().color = playerColors[playerIndex];
        text.GetComponent<typer>().StartRoutines(et.GetFromChoices());
    }
    
    // Display response field
    public void DisplayResponseField (Response r)
    {
        SetButtonsEnable(ScenarioMode.Respond);
        responseBox.GetChild(0).GetComponent<Text>().color = playerColors[playerIndex];
        responseBox.GetChild(0).GetComponent<typer>().StartRoutines(r.GetFromChoices());
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

    private IEnumerator StartWithDelay (float time)
    {
        yield return new WaitForSeconds(time);
        canStart = true;
    }

    // Going through the scnario
    public IEnumerator PlayThroughScenario ()
    {
        finished = false;
        foreach (StoryPart s in currentScenario.scenarioParts)
        {
            moveOn = false;
            playerIndex = s.index;
            playerIndicator.text = string.Format("For Player {0}'s eyes", playerIndex + 1);
            playerIndicator.color = playerColors[playerIndex];
            if (s.GetType() == typeof(Choice))
            {
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
            StopAllTypingRoutines();
        }
        text.GetComponent<Text>().text = "";
        SetButtonsEnable(ScenarioMode.Story);
        finished = true;
    }

    // Stop all typing routines
    private void StopAllTypingRoutines ()
    {
        text.GetComponent<typer>().StopRoutines();
        responseBox.GetChild(0).GetComponent<typer>().StopRoutines();
    }

    // Make the buttons visible or invisible
    private void SetButtonsEnable (ScenarioMode mode)
    {
        currentMode = mode == ScenarioMode.Menu ? currentMode : mode;
        buttons.gameObject.SetActive(mode == ScenarioMode.Choice);
        text.gameObject.SetActive(mode == ScenarioMode.Story);
        responseBox.gameObject.SetActive(mode == ScenarioMode.Respond);
    }

    //play bgm
    private void playSound (int i)
    {
        bgmSource.clip = bgmClips[Mathf.Max(0, i - 1)];
        bgmSource.Play();
    }

    public void resumeGame()
    {
        SetButtonsEnable(currentMode);
    }

}

public enum ScenarioMode
{
    Story,
    Choice,
    Respond,
    Menu
}