using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public int levelToLoad;

	// Use this for initialization
	public void LoadLevel () {
        SceneManager.LoadScene(levelToLoad);
	}
	
	// Update is called once per frame
	public void LevelExit () {
        Application.Quit();
	}
}
