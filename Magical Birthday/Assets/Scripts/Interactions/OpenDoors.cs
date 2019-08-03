using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour, ICheckpoint {

	public bool enterdoor;

	private Animator animator;
	private AudioSource audio;

	void Start(){
		animator = GetComponent<Animator>();
		audio = GetComponent<AudioSource>();
	}

	public void DoTheThing(bool open){
		if (open){
			audio.Play();
			animator.SetTrigger("open");
			if (enterdoor){
				ShoppingList.Instance.ShowList();
				GameManager.Instance.TriggerGameStart();
			}
		} else {
			audio.Play();
			animator.SetTrigger("close");
		}
	}
}
