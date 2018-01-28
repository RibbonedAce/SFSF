using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeSceneButton : MonoBehaviour {
    private string[] scenePaths;
    private AssetBundle myLoadedAssetBundle;

	// Use this for initialization
	void Start () {
        myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/AssetBundles/scenes");
        scenePaths = myLoadedAssetBundle.GetAllScenePaths();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F))
        {
            fadeIn();
        }
	}

    public void changeScene()
    {
        SceneManager.LoadScene(scenePaths[1]);
    }

    public void testFunction()
    {
        return;
    }

    public void fadeIn()
    {
        
    }
}
