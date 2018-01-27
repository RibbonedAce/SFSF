using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioController : MonoBehaviour {
    public static ScenarioController instance;
    public List<Scenario> scenarios;
    public Scenario currentScenario;
    public Text text;
    public Transform buttons;
    private int playerIndex;
    private bool moveOn = false;

    // Use this for initialization
    void Awake ()
    {
        scenarios = new List<Scenario>();
        foreach (TextAsset t in Resources.LoadAll<TextAsset>("Scenarios"))
        {
            scenarios.Add(new Scenario(t.text));
        }
        text.text = "";
        SetButtonsEnable(false);
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
        SetButtonsEnable(false);
        text.text = currentScenario.playerScenarios[playerIndex].startText;
    }

    // Display choices
    public void DisplayChoices ()
    { 
        SetButtonsEnable(true);
        for (int i = 0; i < buttons.childCount; ++i)
        {
            buttons.GetChild(i).Find("Text").GetComponent<Text>().text = currentScenario.playerScenarios[playerIndex].choice.choices[i];
        }
    }

    // Display end text
    public void DisplayEndText ()
    {
        SetButtonsEnable(false);
        string key = "";
        foreach (PlayerScenario p in currentScenario.playerScenarios)
        {
            key += p.choice.decision;
        }
        text.text = currentScenario.playerScenarios[playerIndex].endText[key];
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
    }

    // Make the buttons visible or invisible
    private void SetButtonsEnable (bool visible)
    {
        buttons.gameObject.SetActive(visible);
        text.gameObject.SetActive(!visible);
    }
}
