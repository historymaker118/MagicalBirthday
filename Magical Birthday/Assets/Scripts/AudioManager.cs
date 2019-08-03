using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public static AudioManager Instance;

	public AudioSource exteriorAudio;
	public AudioSource interiorAudio;

	void Awake(){
		if (Instance == null){
			Instance = this;
		}
		exteriorAudio.Play();
	}

	public void SwitchAudio(){
		interiorAudio.Play();
	}
}
