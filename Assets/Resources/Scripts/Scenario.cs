﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario {
    public List<PlayerScenario> playerScenarios;

    public Scenario (string data)
    {
        playerScenarios = new List<PlayerScenario>();
        foreach (string s in data.Split(new string[] { System.Environment.NewLine + System.Environment.NewLine }, System.StringSplitOptions.None))
        {
            playerScenarios.Add(new PlayerScenario(s.Trim()));
        }
    }
}
