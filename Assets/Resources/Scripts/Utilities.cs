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
}
