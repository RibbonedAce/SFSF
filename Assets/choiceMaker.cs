using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class choiceMaker : MonoBehaviour {

	public Text txt;

	// Use this for initialization
	void Start () {
		txt.text = "";
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			txt.text = "No";
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			txt.text = "Yes";
		}
		
	}
}
