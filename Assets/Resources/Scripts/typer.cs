using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class typer : MonoBehaviour {

	Text txt;
	Text tmp;
	private bool t;
    private bool stop = false;

	public float speed;
	public AudioSource mySource;
	public AudioClip[] mySounds;

    public float blinkingSpeed;



	void Awake () 
	{
		txt = GetComponent<Text>();

		mySource = GetComponent<AudioSource>();
		mySounds = Resources.LoadAll<AudioClip>("Audio/typingSound");
	}

    public void StopRoutines ()
    {
        stop = true;
    }

    public void StartRoutines (string text)
    {
        stop = false;
        StartCoroutine(PlayText(text));
        StartCoroutine(PlaySound(text));
    }

	public IEnumerator PlaySound(string story)
	{
		foreach (char c in story) 
		{
			if (t)
			{
				mySource.clip = mySounds[Random.Range(0, mySounds.Length)];
				mySource.Play();
				yield return new WaitForSeconds (0.125f);	
			}
            if (stop)
            {
                break;
            }
		}
	}

    public IEnumerator PlayText(string story)
	{
        t = true;
        txt.text = "";
		foreach (char c in story) 
		{
            txt.text += c;

            string tempTxt = txt.text;
            txt.text += " |";

            yield return new WaitForSeconds(speed);
            txt.text = tempTxt;
            if (stop)
            {
                break;
            }
        }
        t = false;
        StartCoroutine(PlayBlinkingCursor());
    }

    IEnumerator PlayBlinkingCursor()
    {
        string story = txt.text;
        while (!stop)
        {
            txt.text += " |";
            yield return new WaitForSeconds(blinkingSpeed);
            txt.text = story;
            yield return new WaitForSeconds(blinkingSpeed);
        }
    }

}
