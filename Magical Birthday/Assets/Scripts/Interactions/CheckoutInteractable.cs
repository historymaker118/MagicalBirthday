using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckoutInteractable : MonoBehaviour, IInteractable {

	public GameObject prompt;
	public string conversationText;

	private PlayerMovementXZ playerMovement;

	void Start(){
		prompt.SetActive(false);
	}

	public void ShowPrompt(bool showing){
		prompt.SetActive(showing);
	}

	public void DoTheThing(GameObject player){
		if (ShoppingList.Instance.ReadyToCheckout){
			playerMovement = player.GetComponent<PlayerMovementXZ>();
			StartCoroutine(ShowDialog(5f));
		} else if (ShoppingList.Instance.ReadyToLeave){
			Dialog.Instance.UpdateDialog("I've already paid!");
		} else {
			Dialog.Instance.UpdateDialog("I'm still missing a few things...");
		}
	}

	private IEnumerator ShowDialog(float time){
		playerMovement.ToggleMovement(false);
		Dialog.Instance.UpdateDialog(conversationText);
		Scorekeeper.Instance.UpdateScore(250);
		float elapsed = 0;
		while(elapsed < time){
			elapsed += Time.deltaTime;
			yield return null;
		}
		playerMovement.ToggleMovement(true);
		ShoppingList.Instance.ReadyToLeave = true;
		Dialog.Instance.UpdateDialog("Finally! Now to get out of here...");
	}
}
