using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreManager : MonoBehaviour {
// this script compares the new score with the PlayerPrefs data, and replaces old scores with new ones
// also displays "NEW HIGH SCORE" in the event of a new high score...obviously

	[SerializeField]
	private GameObject newHighScoreText = null;
	[SerializeField]
	private InputField nameInputField = null;
	[SerializeField]
	private Button submitButton = null;

	private int newScore;

	// Use this for initialization
	void Start () {
		newHighScoreText.SetActive(false);
		nameInputField.gameObject.SetActive(false);
		submitButton.gameObject.SetActive(false);
	}

	void OnEnable () {
		newScore = ScoreController.GetScore();

		if (isNewHighScore()) {
			newHighScoreText.SetActive(true);

			nameInputField.gameObject.SetActive(true);
			submitButton.gameObject.SetActive(true);
		}
	}

	bool isNewHighScore () {
		int[] highScores = PlayerPrefsManager.GetHighScores();

		foreach (int oldScore in highScores) {
			if (oldScore < newScore) {
				return true;
			}
		}

		return false;
	}

	void AddScoreToHighScoreList () {
		int[] oldHighScores = PlayerPrefsManager.GetHighScores();
		int[] newHighScores = new int[oldHighScores.Length];

		string[] oldNames = PlayerPrefsManager.GetHighScoreNames();
		string[] newNames = new string[oldNames.Length];

		for (int i = oldHighScores.Length - 1; i >= 0; i--) {	
			if (i == 0 || newScore < oldHighScores[i-1]) {
				// add to list, end loop
				for (int j = 0; j < i; j++) {
					newHighScores[j] = oldHighScores[j];
					newNames[j] = oldNames[j];
				}

				newHighScores[i] = newScore;
				newNames[i] = PlayerPrefsManager.GetPlayerName();

				for (int j = i + 1; j < newHighScores.Length; j++) {
					newHighScores[j] = oldHighScores[j-1];
					newNames[j] = oldNames[j-1];
				}

				i = -1;
			}
		}

		PlayerPrefsManager.SaveHighScores(newNames, newHighScores);
	}

	public void SubmitScore () {
		PlayerPrefsManager.SetPlayerName(nameInputField.text);
		AddScoreToHighScoreList();

		nameInputField.interactable = false;
		submitButton.interactable = false;
	}
}
