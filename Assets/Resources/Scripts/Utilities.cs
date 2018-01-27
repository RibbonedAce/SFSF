using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities {
    
    // Merges split strings into one, starting and ending at a specific spot
    public static string MergeString (string[] data, string divider, int start, int end)
    {
        string result = "";
        for (int i = start; i < end; ++i)
        {
            result += data[i] + (i < end - 1 ? divider : "");
        }
        return result;
    }

    // Make a UI object invisible without making it inactive
    public static void MakeInvisible (RectTransform rt)
    {
        rt.anchorMin = new Vector2(-1, -1);
        rt.anchorMax = new Vector2(0, 0);
        rt.offsetMin = Vector2.zero;
        rt.offsetMax = Vector2.zero;
    }
}
