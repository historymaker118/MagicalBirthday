using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject clock;
	public Animator transition;

	public static GameManager Instance;

	private bool _isGameRunning;
	public bool IsGameRunning{
		get { return _isGameRunning; }
		set { _isGameRunning = value; }
	}
	private bool _allowExplosions;
	public bool AllowExplosions {
		get { return _allowExplosions; }
		set { _allowExplosions = value; }
	}

	private AudioSource audio;

	void Start () {
		if (Instance == null){
			Instance = this;
		}
		IsGameRunning = true;
		audio = GetComponent<AudioSource>();
		AllowExplosions = false;
	}

	public void TriggerGameStart(){
		if (clock != null){
			clock.GetComponent<Timer>().StartClock();
		}
		if (audio != null){
			audio.Play();
		}
		AllowExplosions = true;
	}

	public void PauseGame(bool isPaused){
		IsGameRunning = !isPaused;
		if (clock != null){
			if (!IsGameRunning) {
				clock.GetComponent<Timer>().StopClock();
			} else {
				clock.GetComponent<Timer>().StartClock();
			}
		}
	}

	public void TriggerGameOver(){
		////ToDo put in a proper game-over
		//int remainingTime = clock.GetComponent<Timer>().GetRemainingTime();
		//if (remainingTime > 0){
		//	Scorekeeper.Instance.UpdateScore(remainingTime * 10);
		//}
		StartCoroutine(transitionScene(2f));
	}

	private IEnumerator transitionScene(float duration){
		if (transition != null){
			transition.SetTrigger("FadeOut");
		}
		float elapsed = 0;
		while (elapsed < duration){
			elapsed += Time.deltaTime;
			yield return null;
		}
		SceneManager.LoadSceneAsync("GameOver");
	}
}
