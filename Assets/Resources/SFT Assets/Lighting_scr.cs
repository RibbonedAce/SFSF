using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting_scr : MonoBehaviour {
    public List<Light> lights = new List<Light>();
    public List<GameObject> keypadButtons = new List<GameObject>();
    public float brightnessStep;
    public Light flickeringLight;

	// Use this for initialization
	void Start () {
        foreach (Light l in lights)
        {
            l.GetComponent<Light>().intensity = Random.Range(0, 1);
        }
        foreach (GameObject k in keypadButtons)
        {
            Color randColor = new Color(
                Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 
                Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            k.GetComponent<Renderer>().material.SetColor("_EmissionColor", randColor);
        }
	}
	
	// Update is called once per frame
	void Update () {
        addIntensity();
        changeKeyPadColor();
        flickerLight();
    }

    void addIntensity()
    {
        foreach (Light l in lights)
        {
            float currentBrightness = l.GetComponent<Light>().intensity;
            l.GetComponent<Light>().intensity += brightnessStep * Time.deltaTime;
            if (currentBrightness >= 1)
            {
                l.GetComponent<Light>().intensity = 0;
            }
        }
    }

    void changeKeyPadColor()
    {
        foreach (GameObject k in keypadButtons)
        {
            if (Random.Range(0.0f, 1.0f) < 0.6f)
            {
                Color randColor = new Color(
                Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f),
                Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
                k.GetComponent<Renderer>().material.SetColor("_EmissionColor", randColor);
            }
        }
    }

    void flickerLight()
    {
        flickeringLight.GetComponent<Light>().intensity = Random.Range(0.4f, 0.5f);
    }
}
