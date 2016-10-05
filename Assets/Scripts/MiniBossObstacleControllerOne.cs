using UnityEngine;
using System.Collections;

public class MiniBossObstacleControllerOne : MonoBehaviour {

	private int touchCount = 0;
	[SerializeField]
	private int targetTouchCount = 10;

	[SerializeField]
	private GameObject bossMessage = null;

	private PlayerLauncher playerLauncher;

	// Use this for initialization
	void Start () {
		playerLauncher = GameObject.FindObjectOfType<PlayerLauncher>();

		// disable cannon, enable 'X' over cannon object
		RestrictCannon();
	}

	void OnMouseDown () {
		touchCount++;

		if (touchCount >= targetTouchCount) {
			EndRestriction();
		}
	}

	void RestrictCannon () {
		playerLauncher.SetThrowEnabled(false);
	}

	void EndRestriction () {
		playerLauncher.SetThrowEnabled(true);
		bossMessage.SetActive(false);
	}
}
