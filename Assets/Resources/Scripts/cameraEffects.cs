﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraEffects : MonoBehaviour
{
    public GameObject tv;
    public bool zooming = false;
    public float shakeOffset;
    public float amountOfShakes;
    public float waitBetweenShakes;
    public GameObject staticEffect;
    private float t = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t >= 1)
        {
            zooming = true;
        }


        if (zooming)
        {
            StartCoroutine(zoom());
            zooming = false;
        }
    }

    public IEnumerator zoom()
    {
        StartCoroutine(fadeStatic());
        while (Camera.main.orthographicSize > 1f)
        {
            Camera.main.orthographicSize -= 0.1f * Time.deltaTime;
            Vector3 newPos = Vector3.Lerp(Camera.main.transform.position,
                tv.transform.Find("centerCoord").transform.position, 0.1f);
            Camera.main.transform.position = newPos;
            yield return new WaitForSeconds(0.0f);
        }
    }

    public IEnumerator fadeStatic()
    {
        while (staticEffect.GetComponent<SpriteRenderer>().color.a > 0)
        {
            Color newColor = staticEffect.GetComponent<SpriteRenderer>().color;
            newColor.a -= .05f * Time.deltaTime;
            staticEffect.GetComponent<SpriteRenderer>().color = newColor;
            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }

    public IEnumerator cameraShake()
    {
        Vector3 orgPos = Camera.main.transform.position;
        for (int i = 0; i < amountOfShakes; i++)
        {
            int randInt = Random.Range(1, 4);
            switch (randInt)
            {
                case 1:
                    Vector3 left = new Vector3(orgPos.x - shakeOffset, orgPos.y, orgPos.z);
                    Camera.main.transform.position = left;
                    yield return new WaitForSeconds(waitBetweenShakes);
                    break;
                case 2:
                    Vector3 right = new Vector3(orgPos.x + shakeOffset, orgPos.y, orgPos.z);
                    Camera.main.transform.position = right;
                    yield return new WaitForSeconds(waitBetweenShakes);
                    break;
                case 3:
                    Vector3 up = new Vector3(orgPos.x, orgPos.y + shakeOffset, orgPos.z);
                    Camera.main.transform.position = up;
                    yield return new WaitForSeconds(waitBetweenShakes);
                    break;
                case 4:
                    Vector3 down = new Vector3(orgPos.x, orgPos.y - shakeOffset, orgPos.z);
                    Camera.main.transform.position = down;
                    yield return new WaitForSeconds(waitBetweenShakes);
                    break;
            }
        }
        Camera.main.transform.position = orgPos;
    }
}

