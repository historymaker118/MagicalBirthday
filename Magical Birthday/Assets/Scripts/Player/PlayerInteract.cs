using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {

	private bool isPromptShowing;
	private GameObject interactableObj;

	void Update(){
		if (isPromptShowing && Input.GetButtonDown("Interact") && interactableObj != null){
			Debug.Log("Interactive!");
			interactableObj.GetComponent<IInteractable>().DoTheThing(this.gameObject);
		}
	}

	public void OnTriggerEnter2D(Collider2D col){
		switch (col.gameObject.tag){
			case "Collectable":
				col.gameObject.GetComponent<ICollectable>().DoTheThing(this.gameObject);
				break;
			case "Hazard":
				col.gameObject.GetComponent<IHazard>().DoTheThing(this.gameObject);
				break;
			case "Interactable":
				col.gameObject.GetComponent<IInteractable>().ShowPrompt(true);
				interactableObj = col.gameObject;
				isPromptShowing = true;
				break;
			case "Checkpoint":
				col.gameObject.GetComponent<ICheckpoint>().DoTheThing(true);
				break;
		}
	}

	public void OnTriggerExit2D(Collider2D col){
		switch (col.gameObject.tag){
			case "Interactable":
				col.gameObject.GetComponent<IInteractable>().ShowPrompt(false);
				interactableObj = null;
				isPromptShowing = false;
				break;
			case "Checkpoint":
				col.gameObject.GetComponent<ICheckpoint>().DoTheThing(false);
				break;
		}
	}
}
