using UnityEngine;
using System.Collections;

public class EnemyPlacementController : MonoBehaviour {
	[SerializeField]
	private GameObject[] enemyGameObject = null;

	private int enemiesDestroyedCount = 0;

	[SerializeField]
	private int intervalRangeMin = 1, intervalRangeMax = 5;
	private int enemiesBetweenMiniBoss;


	void Start () {
		RandomizeEnemiesBetweenMiniBoss();
	}

	public void EnemyDestroyed (GameObject enemyGameObject) {
		if (enemyGameObject.tag != "MiniBoss") {
			enemiesDestroyedCount++;

			if (enemiesDestroyedCount >= enemiesBetweenMiniBoss) {
				SpawnMiniBoss();
				enemiesDestroyedCount = 0;
			} else {
				SpawnStandardEnemy();
			}
		} else {
			SpawnStandardEnemy();
			enemiesDestroyedCount = 0;
		}
	}

	public void SpawnStandardEnemy () {
		// spawn enemyGameObject[0] (standard enemy)
		Instantiate (enemyGameObject[0]);
	}

	public void SpawnMiniBoss () {
		// spawn boss
		// get rid of normal enemy
		// spawn boss message
		int rand = Mathf.FloorToInt(Random.Range(1f, enemyGameObject.Length - 0.01f));

		Instantiate(enemyGameObject[rand]);

		RandomizeEnemiesBetweenMiniBoss();
	}

	void RandomizeEnemiesBetweenMiniBoss() {
		enemiesBetweenMiniBoss = Mathf.FloorToInt(Random.Range(intervalRangeMin, intervalRangeMax + 0.99f));
	}
}
