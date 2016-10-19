using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour {

	[SerializeField]
	private Text scoreText = null;

	[SerializeField]
	private Text finalScoreText = null;

	private static int currentScore = 0;

	// Use this for initialization
	void Start () {
		scoreText.text = "0";

		currentScore = 0;
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
	}

	public static int GetScore () {
		return currentScore;
	}
}
