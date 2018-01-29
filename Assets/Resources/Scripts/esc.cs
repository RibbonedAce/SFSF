using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class esc : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Escape))
		{
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                SceneManager.LoadScene(2);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
		}
	}

	public void playOnClick()
	{
		//DontDestroyOnLoad(gameObject);
		//Destroy(gameObject, 1);
        SceneManager.LoadScene(1);
    }

	public void creditOnClick()
	{
		StartCoroutine("creditDelay");
	}

	public void endOnClick()
	{
		StartCoroutine("quitDelay");
	}

	public void mainOnClick()
	{
		SceneManager.LoadScene(0);
	}

	private IEnumerator quitDelay()
	{
		yield return new WaitForSeconds(2);
		Application.Quit();
	}

	private IEnumerator creditDelay()
	{
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene(2);
	}

}
