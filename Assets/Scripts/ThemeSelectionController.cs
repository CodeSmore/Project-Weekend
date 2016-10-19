using UnityEngine;
using System.Collections;

public class ThemeSelectionController : MonoBehaviour {
	[SerializeField]
	private GameObject[] backgrounds = null;


	void Start () {
		ActivateTheme();
	}

	void ActivateTheme () {
		DeactivateAllBackgrounds();

		backgrounds[PlayerPrefsManager.GetTheme()].SetActive(true);
	}

	public void SetTheme (int newTheme) {
		PlayerPrefsManager.SetTheme(newTheme);
		ActivateTheme();
	}

//	public void ActivateThemeTwo () {
//		DeactivateAllBackgrounds();
//
//		backgrounds[1].SetActive(true);
//	}
//
//	public void ActivateThemeThree () {
//		DeactivateAllBackgrounds();
//
//		backgrounds[2].SetActive(true);
//	}

	void DeactivateAllBackgrounds () {
		foreach (GameObject background in backgrounds) {
			background.SetActive(false);
		}
	}
}
