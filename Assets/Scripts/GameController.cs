

using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	[SerializeField]
	private GameObject endScreenPanel = null;

	private PlayerLauncher playerLauncher = null;
	private ScoreController scoreController = null;

	[SerializeField]
	private float timeScaleIncrease = 0;

	// Use this for initialization
	void Start () {
		playerLauncher = GameObject.FindObjectOfType<PlayerLauncher>();
		scoreController = GameObject.FindObjectOfType<ScoreController>();

		endScreenPanel.transform.localScale = new Vector3 (1, 1, 1);
		endScreenPanel.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void EndGame () {
		playerLauncher.SetThrowEnabled(false);
		endScreenPanel.SetActive(true);

		scoreController.UpdateEndPanelScores();

		Time.timeScale = 0;
	}

	public void IncreaseGameSpeed () {
		Time.timeScale = Time.timeScale + timeScaleIncrease;
	}
}
