using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

	public AudioMixer mixer;
	public Dropdown resolutionDropdown;
	public Toggle fullscreenToggle;

	private Resolution[] resolutions;

	void Start(){
		resolutions = Screen.resolutions;

		resolutionDropdown.ClearOptions();
		List<string> options = new List<string>();

		fullscreenToggle.isOn = Screen.fullScreen;

		int currentResolutionIndex = 0;
		for (int i=0; i < resolutions.Length; i++){
			string option = resolutions[i].width + "x" + resolutions[i].height;
			options.Add(option);
			
			if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height){
				currentResolutionIndex = i;
			}
		}

		resolutionDropdown.AddOptions(options);
		resolutionDropdown.value = currentResolutionIndex;
		resolutionDropdown.RefreshShownValue();
	}

	public void SetVolumeMusic(float value){
        var volume = Mathf.Log10(value) * 20;
        if (volume > -15f)
        {
            volume = -15f;
        }
		mixer.SetFloat("MusicVolume", volume);
	}

	public void SetVolumeEffects(float value)
    {
        var volume = Mathf.Log10(value) * 20;
        if (volume > -10)
        {
            volume = -10;
        }
        mixer.SetFloat("EffectsVolume", volume);
	}

	public void SetVolumeAmbient(float value){
        var volume = Mathf.Log10(value) * 20;
        if (volume > -17f)
        {
            volume = -17f;
        }
        mixer.SetFloat("AmbienceVolume", volume);
	}

	public void SetQuality(int qualityIndex){
		QualitySettings.SetQualityLevel(4 - qualityIndex);
	}

	public void SetFullscreen(bool isFullscreen){
		Screen.fullScreen = isFullscreen;
	}

	public void SetResolution(int resolutionIndex){
		Resolution res = resolutions[resolutionIndex];
		Screen.SetResolution(res.width, res.height, Screen.fullScreen);
	}
}
