using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCommand : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Destroy after time
    public void DestroyDelay(float time)
    {
        Destroy(gameObject, time);
    }
}
