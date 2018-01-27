using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScenario {
    public string startText;
    public Choice choice;
    public Dictionary<string, string> endText;
    public Dictionary<string, string> responseText;

    public PlayerScenario (string data)
    {
        string[] splitData = data.Split(new string[] { "[partSplit]" }, System.StringSplitOptions.None);
        startText = splitData[0].Trim();
        choice = new Choice(splitData[1].Trim());
        endText = new Dictionary<string, string>();
        string[] ends = splitData[2].Trim().Split(new string[] { "[choiceSplit]" }, System.StringSplitOptions.None);
        endText.Add("AA", ends[0].Trim());
        endText.Add("AB", ends[1].Trim());
        endText.Add("BA", ends[2].Trim());
        endText.Add("BB", ends[3].Trim());
        responseText = new Dictionary<string, string>();
        string[] responses = splitData[3].Trim().Split(new string[] { "[choiceSplit]" }, System.StringSplitOptions.None);
        responseText.Add("AA", responses[0].Trim());
        responseText.Add("AB", responses[1].Trim());
        responseText.Add("BA", responses[2].Trim());
        responseText.Add("BB", responses[3].Trim());
    }
}
