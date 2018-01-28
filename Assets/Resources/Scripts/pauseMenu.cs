using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour {

	public void endOnClick()
		{
			StartCoroutine("quitDelay");
		}

	private IEnumerator quitDelay()
	{
		yield return new WaitForSeconds(1);
		Application.Quit();
	}
}
