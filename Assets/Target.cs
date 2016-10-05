using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	private MiniBossObstacleControllerTwo obstacleController;


	// Use this for initialization
	void Start () {
		obstacleController = GameObject.FindObjectOfType<MiniBossObstacleControllerTwo>();
	}
	
	void OnMouseDown () {
		gameObject.SetActive(false);
		Destroy(gameObject);
	}

	void OnDestroy () {
		obstacleController.CheckIfAllTargetsDestroyed();
	}
}
