using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveStore : MonoBehaviour, ICheckpoint {

	private Animator animator;

	void Start(){
		animator = GetComponent<Animator>();
	}

	public void DoTheThing(bool open){
		if (open){
			if (ShoppingList.Instance.ReadyToLeave){
				animator.SetTrigger("open");
				Scorekeeper.Instance.UpdateScore(100);
				GameManager.Instance.TriggerGameOver();
			} else if (ShoppingList.Instance.ReadyToCheckout){
				Dialog.Instance.UpdateDialog("I have to pay first!");
			} else {
				Dialog.Instance.UpdateDialog("I can't leave yet!");
			}
		} else {
			animator.SetTrigger("close");
		}
	}
}
