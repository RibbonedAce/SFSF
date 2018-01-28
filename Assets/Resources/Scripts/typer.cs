using System.Collections;
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



	void Awake () 
	{
		txt = GetComponent<Text> ();
		story = txt.text;
		txt.text = "";

		t = true;

		mySource = GetComponent<AudioSource>();
		mySounds = Resources.LoadAll<AudioClip>("Audio/typingSound");

		StartCoroutine ("PlayText");
		StartCoroutine ("PlaySound");
	}



	IEnumerator PlayText()
	{
		foreach (char c in story) 
		{
			txt.text += c;
			yield return new WaitForSeconds (speed);
		}
		t = false;
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

}
