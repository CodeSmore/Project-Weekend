using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PlayerLauncher : MonoBehaviour {

	private EventSystem eventSystem;
	private SoundController soundcontroller;

	[SerializeField]
	private GameObject projectile = null;
	[SerializeField]
	private float throwForce = 0;
	[SerializeField]
	private float timeBetweenThrows = 0;

	private float throwTimer = 0;

	private bool throwEnabled = true;

	// Use this for initialization
	void Start () {
		eventSystem = FindObjectOfType<EventSystem>();
		soundcontroller = GameObject.FindObjectOfType<SoundController>();

		throwEnabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0) && eventSystem.currentSelectedGameObject == null && throwEnabled) {
			ThrowSnowball();
		}

		throwTimer += Time.deltaTime;
	}

	private void ThrowSnowball () {
		if (throwTimer > timeBetweenThrows) {
			// first calculate the vector from player launch position to where screen was tapped
			// and normalize it.
			Vector2 touchPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

			Vector2 throwVector = touchPos - new Vector2(transform.position.x, transform.position.y);
			throwVector.Normalize();

			// Then, instantiate the object and apply force according to throwVector
			GameObject thrownObject = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
			thrownObject.GetComponent<Rigidbody2D>().AddForce (throwVector * throwForce);

			soundcontroller.CannonFireClip();

			throwTimer = 0;
		}
	}

	public void SetThrowEnabled (bool change) {
		throwEnabled = change;
	}
}
