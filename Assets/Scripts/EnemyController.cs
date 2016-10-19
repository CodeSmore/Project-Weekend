using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	private GameController gameController;
	private Animator animator;
	private ConveyorController conveyorController;
	private BonusController bonusController;
	private SoundController soundController;

	[SerializeField]
	private float startXPos = 0;
	[SerializeField]
	private float endXPos = 0;

	[SerializeField]
	private float movementRate = 0;

	private float currentXPos = 0;
	private bool endGame = false;
	private bool trippedUp = false;

	void Awake () {
		animator = GetComponent<Animator>();

		if (!animator) {
			animator = GetComponentInChildren<Animator>();
		}

		animator.SetInteger("Theme", PlayerPrefsManager.GetTheme());
		animator.SetTrigger("Start Running");
	}

	// Use this for initialization
	void Start () {
		gameController = GameObject.FindObjectOfType<GameController>();
		conveyorController  = GameObject.FindObjectOfType<ConveyorController>();
		bonusController = GameObject.FindObjectOfType<BonusController>();
		soundController = GameObject.FindObjectOfType<SoundController>();

		gameObject.transform.position = new Vector3 (startXPos, transform.position.y, transform.position.z);

		currentXPos = startXPos;
		endGame = false;

		foreach (Grinder grinder in GameObject.FindObjectsOfType<Grinder>()) {
			grinder.SetBonusValue(gameObject);
		}

		// play entry sound
		if (gameObject.tag != "MiniBoss") {
			soundController.PlayStandardEnemyEntryClip();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (currentXPos >= endXPos && !endGame) {
			gameController.EndGame();
			endGame = true;
		} else if (!trippedUp) {
			currentXPos += movementRate * Time.deltaTime;
		} else {
			currentXPos += Time.deltaTime * conveyorController.GetConveyorSpeed();
		}

		UpdatePETAPosition();
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag == "Obstacle") {

			// trigger trip
			trippedUp = true;

			// bool for fall animation
			animator.SetBool("Fuck it", true);

			// play fall sound
			if (gameObject.tag != "MiniBoss") {
				soundController.PlayStandardEnemyFallClip();
			} else if (gameObject.name == "MiniBoss 1 Body") {
				soundController.PlayBossOneFallClip();
			} else if (gameObject.name == "MiniBoss 2 Body") {
				soundController.PlayBossTwoFallClip();
			} else if (gameObject.name == "MiniBoss 3 Body") {
				soundController.PlayBossThreeFallClip();
			}

			// play can falling animation
			collider.GetComponent<CanController>().PlayHitAnimation();
		}
	}

	void UpdatePETAPosition () {
		gameObject.transform.position = new Vector3 (currentXPos, transform.position.y, transform.position.z);
	}

	void OnDestroy () {
		if (gameObject.tag == "MiniBoss") {
			gameController.IncreaseGameSpeed();

			Destroy(gameObject.transform.parent.gameObject);
		}

		bonusController.ConfirmEnemyDestroyed();
	}
}
