using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatInput : MonoBehaviour {
    public InputField text;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    // Add gotten text to text field
    public void AddToChat ()
    {
        ChatController.instance.AddText(text.text);
        text.text = "";
    }
}
