using UnityEngine;
using System.Collections;

public class TouchIndicator : MonoBehaviour {

	[SerializeField]
	private float lifetime = 2;

	private float lifetimeTimer = 0;
	
	// Update is called once per frame
	void Update () {
		lifetimeTimer += Time.deltaTime;

		if (lifetimeTimer >= lifetime) {
			DestroyImmediate(gameObject);
		}
	}
}
