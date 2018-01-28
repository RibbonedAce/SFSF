using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chat : MonoBehaviour {

    public List<string> chatHistory = new List<string>();

    private string currentMessage = string.Empty;

    private void OnGUI()
    {
        GUILayout.BeginHorizontal(GUILayout.Width(250));
        currentMessage = GUILayout.TextField(currentMessage);
        if (GUILayout.Button("Send"))
        {
            if (!string.IsNullOrEmpty(currentMessage.Trim()))
            {
                //networkView.RPC("ChatMessage", RPCMode.AllBuffered)
            }
        }
        GUILayout.EndHorizontal();

        foreach (string msg in chatHistory)
        {
            GUILayout.Label(msg);
        }
    } 
}
