using UnityEngine;
using System.Collections;

public class ConveyorController : MonoBehaviour {

	[SerializeField]
	private float conveyorSpeed = 1;

	[SerializeField]
	private Transform normalCanSpawnPoint = null;
	[SerializeField]
	private Transform obstacleCanSpawnPoint = null;


	[SerializeField]
	private GameObject normalCan = null;
	[SerializeField]
	private GameObject obstacleCan = null;

	public float GetConveyorSpeed () {
		return conveyorSpeed;
	}

	public void SpawnNormalCan () {
		Instantiate (normalCan, normalCanSpawnPoint.position, Quaternion.identity);
	}

	public void SpawnObstacleCan () {
		Instantiate (obstacleCan, obstacleCanSpawnPoint.position, Quaternion.identity);
	}
}
