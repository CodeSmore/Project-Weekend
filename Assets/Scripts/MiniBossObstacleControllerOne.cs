using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MiniBossObstacleControllerOne : MonoBehaviour {

	private int touchCount = 0;
	[SerializeField]
	private int targetTouchCountMin = 10, targetTouchCountMax = 20;
	private int targetTouchCount;

	[SerializeField]
	private GameObject bossMessage = null;
	[SerializeField]
	private GameObject ProgressCanvas = null;
	[SerializeField]
	private Image progressBarImage = null;

	[SerializeField]
	private GameObject touchIndicator = null;

	private PlayerLauncher playerLauncher;
	private SoundController soundController;

	// Use this for initialization
	void Start () {
		playerLauncher = GameObject.FindObjectOfType<PlayerLauncher>();
		soundController = GameObject.FindObjectOfType<SoundController>();

		soundController.PlayBossOneEntryClip();

		// disable cannon, enable 'X' over cannon object
		RestrictCannon();

		UpdateProgressBar();

		targetTouchCount = Mathf.FloorToInt(Random.Range(targetTouchCountMin, targetTouchCountMax + 0.99f));
	}

	void OnMouseDown () {
		touchCount++;

		Vector2 touchPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		Instantiate(touchIndicator, touchPos, Quaternion.identity);

		UpdateProgressBar();
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
		ProgressCanvas.SetActive(false);

		GetComponent<BoxCollider2D>().enabled = false;
	}

	void UpdateProgressBar () {
		progressBarImage.fillAmount = (float)touchCount / targetTouchCount;
	}
}
