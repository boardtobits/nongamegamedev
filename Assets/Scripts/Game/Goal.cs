using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

	public delegate void GoalReachedHandler();
	public static event GoalReachedHandler OnGoalReached;

	void OnTriggerEnter(Collider c){
		//announce that goal has been reached
		if (OnGoalReached != null){
			OnGoalReached ();
		}
	}
}
