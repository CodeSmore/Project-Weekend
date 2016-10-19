using UnityEngine;
using System.Collections;

public class BonusController : MonoBehaviour {

	[SerializeField]
	private Grinder[] grinders = null;

	private ConveyorController conveyorController;
	private bool enemyDestroyed = false, readyToResetBonus = false, canDeployed = false;

	// Use this for initialization
	void Start () {
		conveyorController = GameObject.FindObjectOfType<ConveyorController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (readyToResetBonus && enemyDestroyed) {
			// reset bonus values
			foreach (Grinder eachGrinder in grinders) {
				eachGrinder.ResetBonusValue();
			}

			enemyDestroyed = false;
			readyToResetBonus = false;
			canDeployed = false;
		}
	}

	public void UpdateBonusObjective () {
		bool reset = true;

		foreach (Grinder eachGrinder in grinders) {
			if (!eachGrinder.IsBonusReady()) {
				reset = false;
			}
		}

		if (reset && !canDeployed) {
			conveyorController.SpawnObstacleCan();
			canDeployed = true;

			readyToResetBonus = true;
		}
	}

	public void ConfirmEnemyDestroyed () {
		enemyDestroyed = true;
	}
}
