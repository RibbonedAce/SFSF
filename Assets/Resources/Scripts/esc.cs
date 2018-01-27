using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class esc : MonoBehaviour {

	public Button playButton;
	public Button creditButton;
	public Button endButton;
	//public Button mainMenuButton;

	// Use this for initialization
	void Start () {
		Button playBtn = playButton.GetComponent<Button>();
		playBtn.onClick.AddListener(playOnClick);
		
		Button creditBtn = creditButton.GetComponent<Button>();
		creditBtn.onClick.AddListener(creditOnClick);

		Button endBtn = endButton.GetComponent<Button>();
		endBtn.onClick.AddListener(endOnClick);

		// Button mainBtn = mainButton.GetComponent<Button>();
		// mainBtn.onClick.AddListener(mainnClick);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Escape))
		{
			SceneManager.LoadScene("escScene", LoadSceneMode.Single);
		}
	}

	void playOnClick()
	{
		SceneManager.LoadScene("playScene", LoadSceneMode.Single);

	}

	void creditOnClick()
	{
		SceneManager.LoadScene("creditScene", LoadSceneMode.Single);
	}

	void endOnClick()
	{
		Application.Quit();
	}

	// void mainOnClick()
	// {
	// 	SceneManager.LoadScene("mainScene", LoadSceneMode.Single);
	// }
}
