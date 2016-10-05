using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MessageController : MonoBehaviour {

	private float flashTimer = 0;

	[SerializeField]
	private float timeForFlash = 0, timeBetweenFlashes = 0;

	private Text messageText;

	// Use this for initialization
	void Start () {
		messageText = GetComponentInChildren<Text>();

		flashTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		flashTimer += Time.deltaTime;

		if (flashTimer >= timeForFlash) {
			if (flashTimer < timeBetweenFlashes + timeForFlash) {
				DisableText();
			} else {
				EnableText();

				flashTimer = 0;
			}
		}
	}

	void DisableText () {
		if (messageText.enabled == true) {
			messageText.enabled = false;
		}
	}

	void EnableText () {
		if (messageText.enabled == false) {
			messageText.enabled = true;
		}
	}
}
