using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Data File/Level Catalog")]
public class LevelCatalog : ScriptableObject {

	[SerializeField]
	LevelData[] levels;

	public int Length { 
		get { 
			return levels.Length; 
		}
	}

	public LevelData GetLevel (int index){
		if (index >= levels.Length || index < 0) {
			return null;
		}
		return levels [index];
	}

	public int GetIndexOf (LevelData data){
		//will return -1 if data is not in catalog
		return System.Array.IndexOf (levels, data);
	}

}
