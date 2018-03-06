using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class SettingsValue : MonoBehaviour {

	Text valueText;

	// Use this for initialization
	void Awake () {
		valueText = GetComponent<Text> ();
	}
	
	public void UpdateValue(float f){
		valueText.text = (f * 100f).ToString("F0") + "%";
	}
}
