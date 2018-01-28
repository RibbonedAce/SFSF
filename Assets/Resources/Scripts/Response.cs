using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Response : StoryPart {
    public List<Choice> conditions;
    public Dictionary<string, string> responses;

    public Response (string data, int newIndex, List<Choice> references)
    {
        index = newIndex;
        conditions = new List<Choice>(references);
        List<string> values = new List<string>(data.Split(new string[] { "[choiceSplit]" }, System.StringSplitOptions.None));
        List<string> keys = Utilities.KeysBySize(2, conditions.Count);
        responses = new Dictionary<string, string>();
        for (int i = 0; i < keys.Count; ++i)
        {
            responses.Add(keys[i], values[i].Trim());
        }
    }

    // Get the decision text
    public string GetFromChoices()
    {
        string key = "";
        foreach (Choice c in conditions)
        {
            key += c.decision;
        }
        return responses[key];
    }
}
