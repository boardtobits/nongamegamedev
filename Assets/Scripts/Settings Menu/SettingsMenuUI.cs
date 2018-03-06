using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenuUI : MonoBehaviour {

	public Slider music, sfx;

	public AudioMixer mixer;

	string musicPref = "Music";
	string sfxPref = "SFX";

	void Start(){
		music.value = 1f - SaveManager.LoadSetting (musicPref);
		sfx.value = 1f - SaveManager.LoadSetting (sfxPref);
	}

	public void SaveSettings(){
		SaveManager.SaveSetting (musicPref, 1f - music.value);
		SaveManager.SaveSetting (sfxPref, 1f - sfx.value);
		mixer.SetFloat("BGMVolume", SliderToMixerValue(music.value));
		mixer.SetFloat ("SFXVolume", SliderToMixerValue (sfx.value));
		ReturnToMainMenu ();
	}

	public void ReturnToMainMenu(){
		SceneLoader.LoadScene (SceneName.MenuMain);
	}

	float SliderToMixerValue(float sliderValue){
		return sliderValue * 35f -35f;
	}

}
