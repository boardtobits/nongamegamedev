using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Data File/Level Data")]
public class LevelData : ScriptableObject {

	public Vector3 playerPosition;
	public Vector3 goalPosition;
	public Vector3[] obstaclePositions;


}
