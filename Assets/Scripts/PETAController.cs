using UnityEngine;
using System.Collections;

public class PETAController : MonoBehaviour {

	private GameController gameController;
	private Animator animator;
	private ConveyorController conveyorController;

	[SerializeField]
	private float startXPos = 0;
	[SerializeField]
	private float endXPos = 0;

	[SerializeField]
	private float movementRate = 0;

	private float currentXPos = 0;
	private bool endGame = false;
	private bool trippedUp = false;

	private float trippedTimer = 0;
	[SerializeField]
	private float trippedDuration = 0;

	// Use this for initialization
	void Start () {
		gameController = GameObject.FindObjectOfType<GameController>();
		animator = GetComponent<Animator>();
		conveyorController  = GameObject.FindObjectOfType<ConveyorController>();

		gameObject.transform.position = new Vector3 (startXPos, transform.position.y, transform.position.z);

		currentXPos = startXPos;
		endGame = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentXPos >= endXPos && !endGame) {
			gameController.EndGame();
			endGame = true;
		} else if (!trippedUp) {
			currentXPos += movementRate * Time.deltaTime;
		} else {
			trippedTimer += Time.deltaTime;

			currentXPos += Time.deltaTime * conveyorController.GetConveyorSpeed();

			if (trippedTimer >= trippedDuration) {
				trippedUp = false;
				animator.SetBool("Fuck it", false);

				trippedTimer = 0;
			}
		}

		UpdatePETAPosition();
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag == "Obstacle") {
			// trigger trip
			trippedUp = true;

			animator.SetBool("Fuck it", true);

			// play can falling animation
			collider.GetComponent<CanController>().PlayHitAnimation();
		}
	}

	void UpdatePETAPosition () {
		if (currentXPos <= -8) {
			currentXPos = startXPos;
		}

		gameObject.transform.position = new Vector3 (currentXPos, transform.position.y, transform.position.z);
	}
}
