using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatController : MonoBehaviour {
    public static ChatController instance;
    public int historySize;
    public ChatWindow window;
    private string content;

    void Awake ()
    {
        instance = this;
    }

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    // Add a statement to chat
    public void AddText (string text)
    {
        content += System.Environment.NewLine + text;
        string[] data = (content.Split(new string[] { System.Environment.NewLine }, System.StringSplitOptions.None));
        if (data.Length > historySize)
        {
            content = Utilities.MergeString(data, System.Environment.NewLine, 1, data.Length);
        }
        window.Display(content);
    }
}
