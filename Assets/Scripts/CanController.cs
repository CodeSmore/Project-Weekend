using UnityEngine;
using System.Collections;

public class CanController : MonoBehaviour {

	private ConveyorController conveyorController;
	private Rigidbody2D canRigidbody;
	private SoundController soundController;

	private bool onConveyor = true;

	private float currentXPosition;

	[SerializeField]
	private Vector2 hitForce = Vector2.zero;


	// Use this for initialization
	void Start () {
		conveyorController = GameObject.FindObjectOfType<ConveyorController>();
		canRigidbody = GetComponent<Rigidbody2D>();
		soundController = GameObject.FindObjectOfType<SoundController>();

		currentXPosition = gameObject.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (onConveyor) {
			UpdateCanPosition();
		}
	}

	void UpdateCanPosition () {
		currentXPosition += conveyorController.GetConveyorSpeed() * Time.deltaTime;

		transform.position = new Vector3 (currentXPosition, transform.position.y, transform.position.z);
	}

	public void PlayHitAnimation () {
		
		if (onConveyor) {
			canRigidbody.isKinematic = false;
			canRigidbody.AddForce(hitForce);

			soundController.KickCanClip();

			onConveyor = false;
		}

	}
}
