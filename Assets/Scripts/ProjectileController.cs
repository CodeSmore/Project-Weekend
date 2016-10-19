using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {
	
	private SpriteRenderer spriteRenderer;
	
	[SerializeField]
	private Sprite[] projectileThemeOneSprites = null;
	[SerializeField]
	private Sprite[] projectileThemeTwoSprites = null;
	[SerializeField]
	private Sprite[] projectileThemeThreeSprites = null;

	[SerializeField]
	private float projectileLifetime = 10;

	private float lifetimeTimer = 0;

	private int currentTheme;
	private int spriteRNG;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();

		currentTheme = PlayerPrefsManager.GetTheme();

		if (currentTheme == 0) {
			spriteRNG = Random.Range(0, projectileThemeOneSprites.Length - 1);

			spriteRenderer.sprite = projectileThemeOneSprites[spriteRNG];
		} else if (currentTheme == 1) {
			spriteRNG = Random.Range(0, projectileThemeTwoSprites.Length - 1);

			spriteRenderer.sprite = projectileThemeTwoSprites[spriteRNG];
		} else if (currentTheme == 2) {
			spriteRNG = Random.Range(0, projectileThemeThreeSprites.Length - 1);
			Debug.Log(spriteRNG);

			spriteRenderer.sprite = projectileThemeThreeSprites[spriteRNG];
		}



		lifetimeTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		lifetimeTimer += Time.deltaTime;

		if (lifetimeTimer >= projectileLifetime) {
			DestroyImmediate(gameObject);
		}
	}	
}
