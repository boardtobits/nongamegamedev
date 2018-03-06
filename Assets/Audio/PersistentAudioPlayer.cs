using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class PersistentAudioPlayer : MonoBehaviour {

	public static PersistentAudioPlayer ins;
	AudioSource player;
	bool initAudio = false;

	public AudioMixer mixer;
	public AudioClip[] musicTracks;
	public AudioMixerSnapshot[] fullAudio, muteBGM;
	public float transitionTime = 0.5f;

	void Awake (){
		if (ins == null) {
			DontDestroyOnLoad (gameObject);
			ins = this;
			player = GetComponent<AudioSource> ();
			player.Play ();
		} else if (ins != this) {
			Destroy (gameObject);
		}
	}

	void Start(){
		if (!initAudio) {
			player.outputAudioMixerGroup.audioMixer.SetFloat ("BGMVolume", SettingToMixerValue (SaveManager.LoadSetting ("Music")));
			player.outputAudioMixerGroup.audioMixer.SetFloat ("SFXVolume", SettingToMixerValue (SaveManager.LoadSetting ("SFX")));
			initAudio = true;
		}
	}

	public void ChangeMusic(int track){
		StartCoroutine (RunChangeMusic (track));
	}

	IEnumerator RunChangeMusic(int track){
		if (musicTracks [track] == player.clip) {
			yield break;
		} else {
			mixer.TransitionToSnapshots (muteBGM, new float[]{ 1.0f }, transitionTime);
			//wait for transition to finish
			yield return new WaitForSeconds(transitionTime);
			player.clip = musicTracks [track];
			player.Play ();
			mixer.TransitionToSnapshots (fullAudio, new float[]{ 1.0f }, transitionTime);
		}



	}

	float SettingToMixerValue(float settingValue){
		return (1f - settingValue) * 35f - 35f;
	}

}
