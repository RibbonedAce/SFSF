using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice : StoryPart {
    public string decision;
    public List<string> choices;

    public Choice (string data, int newIndex)
    {
        index = newIndex;
        decision = "";
        choices = new List<string>();
        foreach (string s in data.Split(new string[] { "[choiceSplit]" }, System.StringSplitOptions.None))
        {
            choices.Add(s.Trim());
        }
    }
}
