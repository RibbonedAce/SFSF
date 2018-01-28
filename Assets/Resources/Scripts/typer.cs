﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class typer : MonoBehaviour {

	Text txt;
	Text tmp;
	string story;
	private bool t;


	public float speed;

	public AudioSource mySource;
	public AudioClip[] mySounds;



    public float blinkingSpeed;


	void Awake () 
	{
		txt = GetComponent<Text>();
		story = txt.text;
		txt.text = "";


		t = true;

		mySource = GetComponent<AudioSource>();
		mySounds = Resources.LoadAll<AudioClip>("Audio/typingSound");

		// TODO: add optional delay when to start

		StartCoroutine ("PlayText");
		StartCoroutine ("PlaySound");
	}

    private void Update()
    {
        /*if (story == txt.text)
        {
            StartCoroutine(PlayBlinkingCursor());
        }*/
    }

	IEnumerator PlaySound()
	{
		foreach (char c in story) 
		{
			if (t == true)
			{
				mySource.clip = mySounds[Random.Range(0, mySounds.Length)];
				mySource.Play();
				yield return new WaitForSeconds (0.125f);	
			}
		}
	}

    IEnumerator PlayText()
	{
		foreach (char c in story) 
		{
            txt.text += c;

            string tempTxt = txt.text;
            txt.text += " |";

            //transform.position += Vector3.right;

            yield return new WaitForSeconds(speed);
            txt.text = tempTxt;
        }
        StartCoroutine(PlayBlinkingCursor());
    }

    IEnumerator PlayBlinkingCursor()
    {
        while (true)
        {
            txt.text += " |";
            yield return new WaitForSeconds(blinkingSpeed);
            txt.text = story;
            yield return new WaitForSeconds(blinkingSpeed);
        }
    }

}
