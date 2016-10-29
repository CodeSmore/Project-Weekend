using UnityEngine;
using System.Collections;

public class GrinderLabel : MonoBehaviour {

	private SpriteRenderer spriteRenderer;

	[SerializeField]
	private Sprite[] sprites = null;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();

		spriteRenderer.sprite = sprites[PlayerPrefsManager.GetTheme()];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
