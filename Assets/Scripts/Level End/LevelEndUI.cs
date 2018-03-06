using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEndUI : MonoBehaviour {

	public Text message;
	public Button restartButton;
	public Text rButtonLabel;

	void Start(){
		if (PlaySessionManager.ins.gameComplete) {
			message.text = "You won the game!";
			restartButton.gameObject.SetActive (false);
			PlaySessionManager.ins.gameComplete = false;
			return;
		}
		bool success = PlaySessionManager.ins.mostRecentEndSuccess;
		message.text = success ? "Level complete!" : "Level failed!";
		rButtonLabel.text = success ? "Next level" : "Try again";
	}

	public void RestartButtonPressed(){
		SceneLoader.LoadScene (SceneName.Level);
	}

	public void MenuButtonPressed(){
		SceneLoader.LoadScene (SceneName.MenuMain);
	}

}
