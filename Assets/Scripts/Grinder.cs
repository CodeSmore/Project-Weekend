using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Grinder : MonoBehaviour {

	private ScoreController scoreController;
	private Text bonusValueText = null;
	private BonusController bonusController;
	private ConveyorController conveyorController;
	private SoundController soundController;

	[SerializeField]
	private int pointValue = 0;

	[SerializeField]
	private int baseBonusValue = 5;
	[SerializeField]
	private float bonusModifier = 1.5f;

	private int currentBonusValue = 0;

	// Use this for initialization
	void Start () {
		scoreController = GameObject.FindObjectOfType<ScoreController>();
		bonusValueText = gameObject.transform.parent.GetComponentInChildren<Text>();
		bonusController = GameObject.FindObjectOfType<BonusController>();
		conveyorController = GameObject.FindObjectOfType<ConveyorController>();
		soundController = GameObject.FindObjectOfType<SoundController>();

		currentBonusValue = baseBonusValue;

		UpdateBonusValueText();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D collider) {
		Destroy(collider.gameObject);

		scoreController.AddScore(pointValue);
		SubtractBonusValue();
		UpdateBonusValueText();
		SpawnNormalCan();
		soundController.CatGrindClip();
		soundController.MeatSplatClip();
	}

	void UpdateBonusValueText () {
		bonusValueText.text = currentBonusValue.ToString();

		if (currentBonusValue == 0) {
			bonusValueText.color = Color.green;
		} else {
			bonusValueText.color = Color.red;
		}
	}

	void SubtractBonusValue () {
		if (currentBonusValue != 0) {
			currentBonusValue--;
		} else {
			bonusController.UpdateBonusObjective();
		}
	}

	public bool IsBonusReady () {
		if (currentBonusValue == 0) {
			return true;
		}

		return false;
	}

	public void ResetBonusValue () {
		int bonusIncrement = Mathf.FloorToInt(baseBonusValue * bonusModifier);

		if (bonusIncrement < 1) {
			bonusIncrement = 1;
		}

		baseBonusValue += bonusIncrement;

		currentBonusValue = baseBonusValue;
		UpdateBonusValueText();
	}

	void SpawnNormalCan () {
		conveyorController.SpawnNormalCan();
	}
}
