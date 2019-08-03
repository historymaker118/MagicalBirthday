using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OldLadyHazard : MonoBehaviour,IHazard {

	public string conversationText;
	public float timeWasted = 3f;

	private bool immunity;
	private PlayerMovementXZ playerMovement;
	private MoveToWaypoint walk;

	void Start(){
		immunity = false;
		walk = GetComponent<MoveToWaypoint>();
	}

	public void DoTheThing(GameObject player){
		if (immunity || player.GetComponent<PlayerUpgrades>().HasImmunity()){
			return;
		}
		playerMovement = player.GetComponent<PlayerMovementXZ>();
		StartCoroutine(TimeWastingConversation(timeWasted));
	}

	public IEnumerator TimeWastingConversation(float timeWasted){
		walk.IsWalking(false);
		playerMovement.ToggleMovement(false);
		Dialog.Instance.UpdateDialog(conversationText);
		float elapsed = 0;
		while (elapsed < timeWasted){
			elapsed += Time.deltaTime;
			yield return null;
		}
		playerMovement.ToggleMovement(true);
		StartCoroutine(Immunity(3f));
		walk.IsWalking(true);
	}

	public IEnumerator Immunity(float duration){
		immunity = true;
		float elapsed = 0;
		while (elapsed < duration){
			elapsed += Time.deltaTime;
			yield return null;
		}
		immunity = false;
	}
}
