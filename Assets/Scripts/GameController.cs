

using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	[SerializeField]
	private GameObject endScreenPanel = null, pauseMenu = null, pauseButton = null;

	private PlayerLauncher playerLauncher = null;
	private ScoreController scoreController = null;

	private float lastTimeScale = 1;

	[SerializeField]
	private float timeScaleIncrease = 0;

	// Use this for initialization
	void Start () {
		playerLauncher = GameObject.FindObjectOfType<PlayerLauncher>();
		scoreController = GameObject.FindObjectOfType<ScoreController>();

		endScreenPanel.transform.localScale = new Vector3 (1, 1, 1);
		endScreenPanel.SetActive(false);
		pauseMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void EndGame () {
		playerLauncher.SetThrowEnabled(false);
		endScreenPanel.SetActive(true);
		pauseButton.SetActive(false);

		scoreController.UpdateEndPanelScores();

		Time.timeScale = 0;
	}

	public void IncreaseGameSpeed () {
		Time.timeScale = Time.timeScale + timeScaleIncrease;
	}

	public void OpenPauseMenu () {
		lastTimeScale = Time.timeScale;

		pauseMenu.SetActive(true);
		pauseButton.SetActive(false);
		Time.timeScale = 0;
	}

	public void ClosePauseMenu () {
		pauseMenu.SetActive(false);
		pauseButton.SetActive(true);
		Time.timeScale = lastTimeScale;
	}
}
