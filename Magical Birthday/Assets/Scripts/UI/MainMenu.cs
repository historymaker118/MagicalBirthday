using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public AudioClip hoverSound;
	public AudioClip clickSound;

	public GameObject titlecard;
	public GameObject loadMenu;
	public GameObject optionsMenu;
	public GameObject scoreboard;

	public string mainSceneName;

	public Animator transition;

	private AudioSource audio;

	void Start () {
		audio = GetComponent<AudioSource>();

		if (titlecard != null){
			titlecard.SetActive(true);
		}
		if (loadMenu != null){
			loadMenu.SetActive(false);
		}
		if (optionsMenu != null){
			optionsMenu.SetActive(false);
		}
		if (scoreboard != null){
			scoreboard.SetActive(false);
		}
	}

	public void HoverSound() {
		audio.PlayOneShot(hoverSound);
	}

	public void StartButton_Click(){
		audio.PlayOneShot(clickSound);
		StartCoroutine(transitionScene(2f));
	}

	public void OptionsButton_Click(){
		audio.PlayOneShot(clickSound);
		if (titlecard != null){
			titlecard.SetActive(false);
		}
		if (loadMenu != null){
			loadMenu.SetActive(false);
		}
		if (optionsMenu != null){
			optionsMenu.SetActive(true);
		}
		if (scoreboard != null){
			scoreboard.SetActive(false);
		}
	}

	public void ScoreboardButton_Click(){
		audio.PlayOneShot(clickSound);
		if (titlecard != null){
			titlecard.SetActive(false);
		}
		if (loadMenu != null){
			loadMenu.SetActive(false);
		}
		if (optionsMenu != null){
			optionsMenu.SetActive(false);
		}
		if (scoreboard != null){
			scoreboard.SetActive(true);
		}
	}

	public void QuitButton_Click(){
		Application.Quit();
	}

	private IEnumerator transitionScene(float duration){
		transition.SetTrigger("FadeOut");
		float elapsed = 0;
		while (elapsed < duration){
			elapsed += Time.deltaTime;
			yield return null;
		}
		SceneManager.LoadSceneAsync(mainSceneName);
	}
}
