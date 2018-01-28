using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartText : StoryPart {
    public string text;

    public StartText (string data, int newIndex)
    {
        index = newIndex;
        text = data;
    }
}
