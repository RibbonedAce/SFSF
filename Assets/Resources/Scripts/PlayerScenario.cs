using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScenario {
    public string startText;
    public Choice choice;
    public Dictionary<string, string> endText;

    public PlayerScenario (string data)
    {
        string[] splitData = data.Split(new string[] { System.Environment.NewLine }, System.StringSplitOptions.None);
        startText = splitData[0].Trim();
        choice = new Choice(splitData[1].Trim());
        endText = new Dictionary<string, string>();
        string[] ends = splitData[2].Trim().Split('|');
        endText.Add("AA", ends[0]);
        endText.Add("AB", ends[1]);
        endText.Add("BA", ends[2]);
        endText.Add("BB", ends[3]);
    }
}
