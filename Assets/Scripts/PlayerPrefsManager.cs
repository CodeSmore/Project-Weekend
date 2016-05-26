using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string HIGH_SCORE_KEY = "high_score";

	public static void SetHighScore (int newScore) {
		PlayerPrefs.SetInt(HIGH_SCORE_KEY, newScore);
	}

	public static int GetHighScore () {
		return PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
	}
}
