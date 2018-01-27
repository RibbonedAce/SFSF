using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ChatText : MonoBehaviour {
    private Text _text;

    void Awake ()
    {
        _text = GetComponent<Text>();
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    // Change the text and its color
    public void Change (string text)
    {
        _text.text = text;
    }
}
