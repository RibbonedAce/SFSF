using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class ChatWindow : MonoBehaviour {
    public InputField input;
    public Text text;
    private RectTransform _rectTransform;

    void Awake ()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    // Add text to the chat
    public void AddToChat ()
    {
        ChatController.instance.AddText(input.text);
        input.text = "";
    }

    // Display the text on the window
    public void Display (string value)
    {
        transform.GetChild(0).GetChild(0).GetComponent<Text>().text = value;
    }
}
