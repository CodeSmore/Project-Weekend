using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	private MiniBossObstacleControllerTwo obstacleController;
	private SoundController soundController;

	// Use this for initialization
	void Start () {
		obstacleController = GameObject.FindObjectOfType<MiniBossObstacleControllerTwo>();
		soundController = GameObject.FindObjectOfType<SoundController>();
	}
	
	void OnMouseDown () {
		gameObject.SetActive(false);
		Destroy(gameObject);
	}

	void OnDestroy () {
		obstacleController.CheckIfAllTargetsDestroyed();
		soundController.TargetTappedClip();
	}
}
