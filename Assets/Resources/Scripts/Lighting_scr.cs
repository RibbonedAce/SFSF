using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting_scr : MonoBehaviour {
    public List<Light> lights = new List<Light>();
    public List<GameObject> keypadButtons = new List<GameObject>();
    public float brightnessStep;
    public Light flickeringLight;
    public Dictionary<Light, bool> flickerBools;

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
        flickerBools = new Dictionary<Light, bool>();
        flickerBools.Add(flickeringLight, false);
        foreach (Light l in lights)
        {
            flickerBools.Add(l, false);
            l.intensity = 1;
        }
        flickeringLight.intensity = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
        List<Light> flickerKeys = new List<Light>(flickerBools.Keys);
        for (int i = 0; i < flickerKeys.Count; ++i)
        {
            if (!flickerBools[flickerKeys[i]])
            {
                if (flickerKeys[i] == flickeringLight)
                {
                    StartCoroutine(flicker(flickerKeys[i], 0.4f, 0.5f));
                }
                else
                {
                    StartCoroutine(flicker(flickerKeys[i], 0, 1));
                }
            }
            
        }
        changeKeyPadColor();
    }

    IEnumerator flicker (Light l, float minI, float maxI)
    {
        flickerBools[l] = true;
        float delay = Random.Range(0, 5);
        float flickers = Random.Range(1, 6);
        List<float> flickerTimes = new List<float>();
        for (int i = 0; i < flickers; ++i)
        {
            flickerTimes.Add(Random.Range(0.05f, 0.2f));
        }
        yield return new WaitForSeconds(delay);
        foreach (float f in flickerTimes)
        {
            for (float time = Time.deltaTime; time < f / 2; time += Time.deltaTime)
            {
                l.intensity = maxI * (1 - time / (f / 2)) + minI * time / (f / 2);
                yield return new WaitForEndOfFrame();
            }
            l.intensity = minI;
            for (float time = Time.deltaTime; time < f / 2; time += Time.deltaTime)
            {
                l.intensity = minI * (1 - time / (f / 2)) + maxI * time / (f / 2);
                yield return new WaitForEndOfFrame();
            }
            l.intensity = maxI;
        }
        flickerBools[l] = false;
        /*foreach (Light l in lights)
        {
            float currentBrightness = l.GetComponent<Light>().intensity;
            l.GetComponent<Light>().intensity += brightnessStep * Time.deltaTime;
            if (currentBrightness >= 1)
            {
                l.GetComponent<Light>().intensity = 0;
            }
        }*/
    }

    void changeKeyPadColor()
    {
        foreach (GameObject k in keypadButtons)
        {
            if (Random.Range(0.0f, 1.0f) < 0.087f)
            {
                Color randColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1);
                k.GetComponent<Renderer>().material.SetColor("_EmissionColor", Utilities.NormalizeColor(randColor, false));
            }
        }
    }
}
