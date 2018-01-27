using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class esc : MonoBehaviour {

	public Button playButton;

	// Use this for initialization
	void Start () {
		Button btn = playButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Escape))
		{
			SceneManager.LoadScene("escScene", LoadSceneMode.Single);
		}

		
	}

	void TaskOnClick()
	{
		if (playButton.tag == "play button")
			SceneManager.LoadScene("escScene", LoadSceneMode.Single);

		if (playButton.tag == "main menu")
			SceneManager.LoadScene("mainMenuScene", LoadSceneMode.Single);

		if (playButton.tag == "credit")
			SceneManager.LoadScene("creditScene", LoadSceneMode.Single);

		if (playButton.tag == "end")
			Application.Quit();
	}
}
