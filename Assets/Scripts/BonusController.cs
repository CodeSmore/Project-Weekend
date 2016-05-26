using UnityEngine;
using System.Collections;

public class BonusController : MonoBehaviour {

	[SerializeField]
	private Grinder[] grinders = null;

	private ConveyorController conveyorController;

	// Use this for initialization
	void Start () {
		conveyorController = GameObject.FindObjectOfType<ConveyorController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateBonusObjective () {
		bool reset = true;

		foreach (Grinder eachGrinder in grinders) {
			if (!eachGrinder.IsBonusReady()) {
				reset = false;
			}
		}

		if (reset) {
			Debug.Log("Spawn Bonus Can");
			conveyorController.SpawnObstacleCan();

			// reset bonus values
			foreach (Grinder eachGrinder in grinders) {
				eachGrinder.ResetBonusValue();
			}
		}
	}
}
