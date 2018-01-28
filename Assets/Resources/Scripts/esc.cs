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
			SceneManager.LoadScene("escScene", LoadSceneMode.Single);
		}
	}

	public void playOnClick()
	{
		DontDestroyOnLoad(gameObject);
		Destroy(gameObject, 1);
		SceneManager.LoadScene("cockpit", LoadSceneMode.Single);

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
		SceneManager.LoadScene("beginningScene", LoadSceneMode.Single);
	}

	private IEnumerator quitDelay()
	{
		yield return new WaitForSeconds(2);
		Application.Quit();
	}

	private IEnumerator creditDelay()
	{
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene("creditScene", LoadSceneMode.Single);
	}

}
