using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

	void OnTriggerExit2D (Collider2D collider) {
		Destroy(collider.gameObject);
	}
}
