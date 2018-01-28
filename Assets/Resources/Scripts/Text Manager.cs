using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour {
    public string startingText;
    public List<string> branch1 = new List<string>(3);
    public List<string> currentBranch;


	// Use this for initialization
	void Start () {
        startingText = "Base";
        branch1.Add("1");
        branch1.Add("2");
        branch1.Add("3");

        currentBranch = branch1;
        display();
    }

    void display()
    {
        Debug.Log("Current branch: " + currentBranch);
        for (int i = 0; i < currentBranch.Count; i++)
        {
            Debug.Log(currentBranch[i]);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
