using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	//OBJECTS
	public Player player;
	public Goal goal;
	public Transform obstacleFolder;
	public Transform obstaclePrefab;

	//EVENTS
	public delegate void LevelStartHandler(LevelData levelData);
	public static event LevelStartHandler OnLevelStart;
	public delegate void LevelEndHandler(bool levelCompleted);
	public static event LevelEndHandler OnLevelEnd;

	void Awake(){
		OnLevelStart += SetUpLevel;
		Goal.OnGoalReached += EndLevel;
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			//TODO: Special unsubscribe method?
			OnLevelStart -= SetUpLevel;
			Goal.OnGoalReached -= EndLevel;
			SceneLoader.LoadScene (SceneName.MenuMain);
		}
	}

	//universal call to start level (use after Awake)
	public static void StartLevel(LevelData levelData){
		if (OnLevelStart != null) {
			OnLevelStart (levelData);
		}
	}

	//Positions player, goal and instantiates obstacles (assinged to Level Start event)
	void SetUpLevel(LevelData levelData){
		if (levelData == null)
			return;
		ClearObstacles ();
		player.transform.position = new Vector3 (levelData.playerPosition.x, player.transform.position.y, levelData.playerPosition.z);
		goal.transform.position = new Vector3 (levelData.goalPosition.x, goal.transform.position.y, levelData.goalPosition.z);
		for (int i = 0; i < levelData.obstaclePositions.Length; i++) {
			Transform newObstacle = Instantiate (obstaclePrefab) as Transform;
			newObstacle.position = new Vector3 (levelData.obstaclePositions [i].x, obstaclePrefab.position.y, levelData.obstaclePositions [i].z);
			newObstacle.parent = obstacleFolder;
		}
	}

	//Clears all children in obstacle folder
	void ClearObstacles(){
		foreach (Transform child in obstacleFolder) {
			Destroy (child.gameObject);
		}
	}

	//Call when level is ended (assigned to Goal Reached event)
	void EndLevel(){
		OnLevelStart -= SetUpLevel;
		Goal.OnGoalReached -= EndLevel;
		if (OnLevelEnd != null) {
			OnLevelEnd (true);
		}
	}




}
