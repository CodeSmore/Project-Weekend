using UnityEngine;
using System.Collections;

public class Spinner : MonoBehaviour {

	[SerializeField]
	private float spinSpeed = 1;

	private float currentZRotation = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		currentZRotation += spinSpeed * Time.deltaTime;

		transform.localRotation = Quaternion.Euler(0, 0, currentZRotation);
	}
}
