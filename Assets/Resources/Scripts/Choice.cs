using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice {
    public string decision;
    public List<string> choices;

    public Choice (string data)
    {
        decision = "";
        choices = new List<string>();
        foreach (string s in data.Split(new string[] { "[choiceSplit]" }, System.StringSplitOptions.None))
        {
            choices.Add(s.Trim());
        }
    }
}
