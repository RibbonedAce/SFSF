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
		SceneManager.LoadScene("Main", LoadSceneMode.Single);

	}

	public void creditOnClick()
	{
		SceneManager.LoadScene("creditScene", LoadSceneMode.Single);
	}

	public void endOnClick()
	{
		Application.Quit();
	}

	public void mainOnClick()
	{
		SceneManager.LoadScene("beginningScene", LoadSceneMode.Single);
	}

}
