using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {
	private EnemyPlacementController enemyPlacementController;

	void Start () {
		enemyPlacementController = GameObject.FindObjectOfType<EnemyPlacementController>();
	}

	void OnTriggerExit2D (Collider2D collider) {
		if (collider.gameObject.GetComponent<EnemyController>()) {
			enemyPlacementController.EnemyDestroyed(collider.gameObject);
		}

		Destroy(collider.gameObject);
	}
}
