using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour {

	public void StartButtonPressed(){
		SceneLoader.LoadScene (SceneName.Level);
	}

	public void LevelSelectButtonPressed(){
		SceneLoader.LoadScene (SceneName.MenuLevelSelect);
	}

	public void SettingsButtonPressed(){
		SceneLoader.LoadScene (SceneName.MenuSettings);
	}

}
