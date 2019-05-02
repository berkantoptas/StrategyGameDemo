using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {


	// Use this for initialization
	void Start () {

        StartCoroutine(LoadGame());
	}
	

    IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene(1);
    }
}
