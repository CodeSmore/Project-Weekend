using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ReloadLevel () {
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void LoadLevel (string level) {
		SceneManager.LoadScene(level);
	}

	public void Quit () {
		Application.Quit();
	}
}
