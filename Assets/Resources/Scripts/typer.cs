using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class typer : MonoBehaviour {

	Text txt;
	string story;
	public float speed;
    public float blinkingSpeed;

	void Awake () 
	{
		txt = GetComponent<Text>();
		story = txt.text;
		txt.text = "";

        transform.position = txt.transform.position;
		// TODO: add optional delay when to start
		StartCoroutine ("PlayText");
	}

    private void Update()
    {
        /*if (story == txt.text)
        {
            StartCoroutine(PlayBlinkingCursor());
        }*/
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
