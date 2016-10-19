using UnityEngine;
using System.Collections;

public class MiniBossObstacleControllerThree : MonoBehaviour {

	[SerializeField]
	private GameObject[] coverGameObjects = null;

	[SerializeField]
	private float cycleCoversIntervalInSeconds = -1;
	private float timer = 0;
	private int currentActiveCover = 0;

	private SoundController soundController;

	// Use this for initialization
	void Start () {
		soundController = GameObject.FindObjectOfType<SoundController>();

		soundController.PlayBossThreeEntryClip();

		// give 1 second with all covered
		timer = cycleCoversIntervalInSeconds - 1f;
	}

	void Update () {
		if (timer >= cycleCoversIntervalInSeconds) {
			CycleCovers();
			timer = 0;
		}

		timer += Time.deltaTime;
	}

	void CycleCovers () {
		// play sound
		soundController.CoversCycleClip();

		for (int i = 0; i < coverGameObjects.Length; i++) {
			if (currentActiveCover == i) {
				coverGameObjects[i].SetActive(true);
			} else {
				coverGameObjects[i].SetActive(false);
			}
		}

		if (currentActiveCover < coverGameObjects.Length - 1) {
			currentActiveCover++;
		} else {
			currentActiveCover = 0;
		}
	}
}
