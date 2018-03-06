using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectUI : MonoBehaviour {

	public LevelSelectButton buttonPrefab;
	public Transform buttonContainer;


	void Start(){
		for (int i = 0; i <= PlaySessionManager.ins.FurthestLevel; i++) {
			LevelSelectButton newButton = Instantiate (buttonPrefab, buttonContainer);
			newButton.Initialize (this, i);
		}
	}



	public void BackButtonPressed(){
		SceneLoader.LoadScene (SceneName.MenuMain);
	}

	public void LevelButtonPressed(int levelIndex){
		//set PlaySessionManager
		PlaySessionManager.ins.CurrentLevel = levelIndex;
		//change the scene
		SceneLoader.LoadScene (SceneName.Level);
	}

}
