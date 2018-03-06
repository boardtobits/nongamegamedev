using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectButton : MonoBehaviour {

	LevelSelectUI ui;
	int levelIndex;

	public void Initialize(LevelSelectUI ui, int levelIndex){
		this.ui = ui;
		this.levelIndex = levelIndex;
		GetComponentInChildren<Text> ().text = "Level " + levelIndex;
	}

	public void OnPress(){
		ui.LevelButtonPressed (levelIndex);
	}

}
