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
        choices.AddRange(data.Split('|'));
    }
}
