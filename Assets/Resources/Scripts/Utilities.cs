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

    // Make a list of strings depending on width and length
    public static List<string> KeysBySize (int width, int length)
    {
        List<string> result = new List<string>();
        if (length <= 0)
        {
            result.Add("");
            return result;
        }
        List<string> before = KeysBySize(width, length - 1);
        for (int i = 0; i < width; ++i)
        {
            List<string> toAdd = new List<string>(before);
            for (int j = 0; j < toAdd.Count; ++j)
            {
                toAdd[j] = ((char)('A' + i)).ToString() + toAdd[j];
            }
            result.AddRange(toAdd);
        }
        return result;
    }

    // Get an array of integers from a string separated by a divider
    public static int[] ParseInts (string data, string divider)
    {
        string[] nums = data.Split(new string[] { divider }, System.StringSplitOptions.None);
        int[] result = new int[nums.Length];
        for (int i = 0; i < nums.Length; ++i)
        {
            result[i] = (int.Parse(nums[i]));
        }
        return result;
    }

    // Normalize a color to be brighter
    public static Color NormalizeColor (Color color, bool useAlpha)
    {
        float max = Mathf.Max(color.r, color.b, color.g, useAlpha ? color.a : 0);
        if (max == 0)
        {
            return useAlpha ? Color.clear : Color.black;
        }
        return new Color(color.r / max, color.b / max, color.g / max, useAlpha ? color.a / max : color.a);
    }
}
