using UnityEngine;
using System.Collections;

public class MiniBossObstacleControllerTwo : MonoBehaviour {

	[SerializeField]
	private GameObject bossMessage = null;

	private PlayerLauncher playerLauncher;

	// Use this for initialization
	void Start () {
		playerLauncher = GameObject.FindObjectOfType<PlayerLauncher>();

		// disable cannon, enable 'X' over cannon object
		RestrictCannon();
	}

	public void CheckIfAllTargetsDestroyed () {
		// if all targets destroyed
		//...EndRestriction
		bool allDestroyed = true;

		foreach (Transform target in gameObject.transform) {
			if (target.gameObject.activeSelf) {
				allDestroyed = false;
			}
		}


		if (allDestroyed) {
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
