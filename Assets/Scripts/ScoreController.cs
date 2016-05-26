using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour {

	[SerializeField]
	private Text scoreText = null;

	[SerializeField]
	private Text finalScoreText = null;
	[SerializeField]
	private Text highScoreText = null;

	private int currentScore = 0;

	// Use this for initialization
	void Start () {
		scoreText.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddScore (int score) {
		currentScore += score;

		UpdateScoreText();
	}

	public void UpdateScoreText () {
		scoreText.text = currentScore.ToString();
	}

	public void UpdateEndPanelScores () {
		finalScoreText.text = currentScore.ToString();

		int highScore = PlayerPrefsManager.GetHighScore();

		if (currentScore > highScore) {
			highScore = currentScore;

			PlayerPrefsManager.SetHighScore(highScore);
		}

		highScoreText.text = highScore.ToString();
	}
}
