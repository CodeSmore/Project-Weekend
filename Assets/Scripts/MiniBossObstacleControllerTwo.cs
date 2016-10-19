using UnityEngine;
using System.Collections;

public class MiniBossObstacleControllerTwo : MonoBehaviour {

	[SerializeField]
	private GameObject bossMessage = null;

	[SerializeField]
	private GameObject targetGameObject = null;
	[SerializeField]
	private int minNumTargets = 0, maxNumTargets = 0;

	private PlayerLauncher playerLauncher;
	private SoundController soundController;

	// Use this for initialization
	void Start () {
		playerLauncher = GameObject.FindObjectOfType<PlayerLauncher>();
		soundController = GameObject.FindObjectOfType<SoundController>();

		soundController.PlayBossTwoEntryClip();

		// disable cannon, enable 'X' over cannon object
		RestrictCannon();
		SpawnTargets();
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

	void SpawnTargets () {
		int numTargets = Mathf.FloorToInt(Random.Range(minNumTargets, maxNumTargets + 0.99f));

		for (int i = 0; i < numTargets; i++) {
			Vector2 targetSpawnPoint = Camera.main.ViewportToWorldPoint(new Vector3 (Random.Range(0.2f, 0.8f), Random.Range(0.2f, 0.8f), 0));

			GameObject target = Instantiate(targetGameObject, targetSpawnPoint, Quaternion.identity) as GameObject;
			target.transform.SetParent(gameObject.transform);
		}
	}
}
