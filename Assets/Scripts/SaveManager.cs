using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class SaveManager {

	static string path = "/Saves/";
	static string filename = "savedGame";
	static string ext = ".sg";

	public static void SaveGameData(SaveData data){
		//PlayerPrefs.SetInt ("FurthestLevel", PlaySessionManager.ins.FurthestLevel);
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.dataPath + path + filename + ext);
		bf.Serialize (file, data);
		file.Close ();
	}

	public static SaveData LoadGameData(){
		//PlaySessionManager.ins.FurthestLevel = PlayerPrefs.GetInt ("FurthestLevel");
		if (File.Exists(Application.dataPath + path + filename + ext)){
			//load data
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open (Application.dataPath + path + filename + ext, FileMode.Open);
			SaveData data = (SaveData)bf.Deserialize (file);
			file.Close ();
			return data;
		} else {
			//if no data has ever been saved, start at level 0
			return new SaveData(0, 0f, "New Player");
		}
	}

	public static void ClearSaves(){
		PlayerPrefs.DeleteAll ();
		Debug.Log ("Saves cleared");
	}

	public static void SaveSetting(string label, float value){
		PlayerPrefs.SetFloat (label, value);
	}

	public static float LoadSetting (string label){
		return PlayerPrefs.GetFloat (label);
	}
}

[System.Serializable]
public class SaveData {
	public int furthestLevel;
	public float bestTime;
	public string playerName;

	public SaveData (int furthestLevel, float bestTime, string playerName){
		this.furthestLevel = furthestLevel;
		this.bestTime = bestTime;
		this.playerName = playerName;
	}
}
