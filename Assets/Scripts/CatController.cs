using UnityEngine;
using System.Collections;

public class CatController : MonoBehaviour {
	
	private SpriteRenderer spriteRenderer;
	
	[SerializeField]
	private Sprite[] catSprites = null;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();

		int catSpriteRNG = Random.Range(0, catSprites.Length - 1);

		spriteRenderer.sprite = catSprites[catSpriteRNG];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
