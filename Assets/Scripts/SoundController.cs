using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

	private AudioSource audioSource;

	[SerializeField]
	private AudioClip kickCan = null;
	[SerializeField]
	private AudioClip catGrind = null;
	[SerializeField]
	private AudioClip meatSplat = null;
	[SerializeField]
	private AudioClip cannonFire = null;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void KickCanClip () {
		audioSource.PlayOneShot(kickCan);
	}

	public void CatGrindClip () {
		audioSource.PlayOneShot(catGrind);
	}

	public void MeatSplatClip () {
		audioSource.PlayOneShot(meatSplat);
	}

	public void CannonFireClip () {
		audioSource.PlayOneShot(cannonFire);
	}
}
