 using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

	private AudioSource audioSource;

	[SerializeField]
	private AudioClip kickCan = null;
	[SerializeField]
	private AudioClip coversCycle = null;
	[SerializeField]
	private AudioClip targetTapped = null;
	[SerializeField]
	private AudioClip[] projectileGrind = null;
	[SerializeField]
	private AudioClip meatSplat = null;
	[SerializeField]
	private AudioClip[] cannonFire = null;
	[SerializeField]
	private AudioClip[] standardEnemyEnterClip = null, bossOneEnterClip = null, bossTwoEnterClip = null, bossThreeEnterClip = null;
	[SerializeField]
	private AudioClip[] standardEnemyFallClip = null, bossOneFallClip = null, bossTwoFallClip = null, bossThreeFallClip = null;

	// Use this for initialization
	void Awake () {
		audioSource = GetComponent<AudioSource>();
	}

	public void KickCanClip () {
		audioSource.PlayOneShot(kickCan);
	}

	public void ProjectileGrindClip () {
		audioSource.PlayOneShot(projectileGrind[PlayerPrefsManager.GetTheme()]);
	}

	public void MeatSplatClip () {
		audioSource.PlayOneShot(meatSplat);
	}

	public void CannonFireClip () {
		audioSource.PlayOneShot(cannonFire[PlayerPrefsManager.GetTheme()]);
	}

	public void CoversCycleClip () {
		audioSource.PlayOneShot(coversCycle);
	}

	public void TargetTappedClip () {
		audioSource.PlayOneShot(targetTapped);
	}



	public void PlayStandardEnemyEntryClip () {
		audioSource.PlayOneShot(standardEnemyEnterClip[PlayerPrefsManager.GetTheme()]);
	}

	public void PlayBossOneEntryClip () {
		audioSource.PlayOneShot(bossOneEnterClip[PlayerPrefsManager.GetTheme()]);
	}

	public void PlayBossTwoEntryClip () {
		audioSource.PlayOneShot(bossTwoEnterClip[PlayerPrefsManager.GetTheme()]);
	}

	public void PlayBossThreeEntryClip () {
		audioSource.PlayOneShot(bossThreeEnterClip[PlayerPrefsManager.GetTheme()]);
	}



	public void PlayStandardEnemyFallClip () {
		audioSource.PlayOneShot(standardEnemyFallClip[PlayerPrefsManager.GetTheme()]);
	}

	public void PlayBossOneFallClip () {
		audioSource.PlayOneShot(bossOneFallClip[PlayerPrefsManager.GetTheme()]);
	}

	public void PlayBossTwoFallClip () {
		audioSource.PlayOneShot(bossTwoFallClip[PlayerPrefsManager.GetTheme()]);
	}

	public void PlayBossThreeFallClip () {
		audioSource.PlayOneShot(bossThreeFallClip[PlayerPrefsManager.GetTheme()]);
	}
}
