using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SceneLoader {

	const int PROLOGUE_SCENES = 2;

	//METHOD: Load scene based on enum
	public static void LoadScene(SceneName name){
		UnityEngine.SceneManagement.SceneManager.LoadScene ((int)name);
	}

	public static void LoadChapter(int n){
		
	}
}

public enum SceneName {
	MenuMain,
	Level,
	LevelEnd,
	MenuLevelSelect,
	MenuSettings
}
