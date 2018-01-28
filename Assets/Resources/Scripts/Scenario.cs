using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario {
    public List<StoryPart> scenarioParts;

    public Scenario (string data)
    {
        scenarioParts = new List<StoryPart>();
        foreach (string s in data.Split(new string[] { "[partSplit]" }, System.StringSplitOptions.None))
        {
            string[] args = s.Substring(s.IndexOf('{') + 1, s.IndexOf('}') - s.IndexOf('{') - 1).Split(';');
            switch (args[0])
            {
                case "Choice":
                    scenarioParts.Add(new Choice(s.Substring(s.IndexOf('}') + 1), int.Parse(args[1])));
                    break;
                case "Response":
                    List<Choice> list0 = new List<Choice>();
                    int[] choiceIndices0 = Utilities.ParseInts(args[2], ",");
                    int track0 = 0;
                    int indexTrack0 = 0;
                    foreach (StoryPart sp in scenarioParts)
                    {
                        if (sp.GetType() == typeof(Choice) && track0++ == choiceIndices0[indexTrack0])
                        {
                            list0.Add((Choice)sp);
                            ++indexTrack0;
                        }
                    }
                    scenarioParts.Add(new Response(s.Substring(s.IndexOf('}') + 1), int.Parse(args[1]), list0));
                    break;
                case "StartText":
                    scenarioParts.Add(new StartText(s.Substring(s.IndexOf('}') + 1), int.Parse(args[1])));
                    break;
                case "EndText":
                    List<Choice> list1 = new List<Choice>();
                    int[] choiceIndices1 = Utilities.ParseInts(args[2], ",");
                    int track1 = 0;
                    int indexTrack1 = 0;
                    foreach (StoryPart sp in scenarioParts)
                    {
                        if (sp.GetType() == typeof(Choice) && track1++ == choiceIndices1[indexTrack1])
                        {
                            list1.Add((Choice)sp);
                            ++indexTrack1;
                        }
                    }
                    scenarioParts.Add(new EndText(s.Substring(s.IndexOf('}') + 1), int.Parse(args[1]), list1));
                    break;
            }
        }
    }
}
