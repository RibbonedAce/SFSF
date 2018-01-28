using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blinkingCursor : MonoBehaviour {
    private float t = 0;
    private float speed;

    // transparent plus not transparent time in seconds
    private float blinkCycle = 1;

  	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;
        if (t > blinkCycle)
        {
            t = 0;
        }
        if (t > blinkCycle/2 && t < blinkCycle)
        {
            GetComponent<Image>().color = new Color(1f,1f,1f,0f);
        }
        else
        {
            GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
        }
	}

    
}
