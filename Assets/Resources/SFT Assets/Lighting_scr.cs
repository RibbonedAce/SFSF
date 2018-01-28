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
        foreach (Light l in lights)
        {
            flickerBools.Add(l, false);
            l.intensity = 1;
        }
	}
	
	// Update is called once per frame
	void Update () {
        foreach (Light l in flickerBools.Keys)
        {
            if (!flickerBools[l])
            {
                StartCoroutine(addIntensity(l));
            }
        }
        changeKeyPadColor();
        flickerLight();
    }

    IEnumerator addIntensity(Light l)
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
                l.intensity = 1 - time / (f / 2);
                yield return new WaitForEndOfFrame();
            }
            l.intensity = 0;
            for (float time = Time.deltaTime; time < f / 2; time += Time.deltaTime)
            {
                l.intensity = time / (f / 2);
                yield return new WaitForEndOfFrame();
            }
            l.intensity = 1;
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
            if (Random.Range(0.0f, 1.0f) < 0.6f)
            {
                Color randColor = new Color(
                Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f),
                Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
                k.GetComponent<Renderer>().material.SetColor("_EmissionColor", randColor);
            }
        }
    }

    void flickerLight ()
    {
        flickeringLight.intensity = Random.Range(0.4f, 0.5f);
    }
}
