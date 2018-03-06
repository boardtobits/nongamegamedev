using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySessionManager : MonoBehaviour {

	public static PlaySessionManager ins;

	public LevelCatalog catalog;
	int currentLevel = 0;
	int furthestLevel = 0;
	SaveData data;
	public bool mostRecentEndSuccess = false;
	public bool gameComplete = false;

	public int CurrentLevel { set { currentLevel = value; } }
	public int FurthestLevel { 
		get { return furthestLevel; } 
		set { furthestLevel = value; }
	}

	void Awake(){
		//Singleton pattern
		if (ins == null) {
			ins = this;
			DontDestroyOnLoad (gameObject);
		} else if (ins != this) {
			Destroy (gameObject);
			return;
		}
		//Get player data
		data = SaveManager.LoadGameData ();
		furthestLevel = data.furthestLevel;

		//Subscribe to level events
		SceneManager.sceneLoaded += OnSceneLoad;
		LevelManager.OnLevelEnd += HandleLevelEnd;

	}

	void OnSceneLoad(Scene s, LoadSceneMode lsm){
		if (s.name == "level") {
			LevelManager.StartLevel (catalog.GetLevel (currentLevel));
			PersistentAudioPlayer.ins.ChangeMusic (1);
		} else {
			PersistentAudioPlayer.ins.ChangeMusic (0);
		}
	}

	void HandleLevelEnd(bool levelCompleted){
		mostRecentEndSuccess = levelCompleted;
		if (levelCompleted) {
			currentLevel++;
			if (currentLevel >= catalog.Length) {
				currentLevel = 0;
				gameComplete = true;
			}
			if (currentLevel > furthestLevel) {
				furthestLevel = currentLevel;
				data.furthestLevel = furthestLevel;
				SaveManager.SaveGameData (data);
			}
		}
		SceneLoader.LoadScene (SceneName.LevelEnd);
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Equals)) {
			SaveManager.ClearSaves ();
		}
	}

}
