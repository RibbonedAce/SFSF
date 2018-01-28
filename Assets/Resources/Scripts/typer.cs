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
<<<<<<< HEAD
	public AudioSource mySource;
	public AudioClip[] mySounds;


=======
    public float blinkingSpeed;
>>>>>>> 038cffdf5b14af56b6643f2ea1df23e137e991fb

	void Awake () 
	{
		txt = GetComponent<Text>();
		story = txt.text;
		txt.text = "";

<<<<<<< HEAD
		t = true;

		mySource = GetComponent<AudioSource>();
		mySounds = Resources.LoadAll<AudioClip>("Audio/typingSound");

=======
        transform.position = txt.transform.position;
		// TODO: add optional delay when to start
>>>>>>> 038cffdf5b14af56b6643f2ea1df23e137e991fb
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


<<<<<<< HEAD

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
=======
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
>>>>>>> 038cffdf5b14af56b6643f2ea1df23e137e991fb

}
