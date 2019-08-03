using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunningUpgrade : MonoBehaviour, IInteractable {

	public GameObject prompt;
	public string conversationText;

	void Start(){
		prompt.SetActive(false);
	}

	public void ShowPrompt(bool showing){
		prompt.SetActive(showing);
	}

	public void DoTheThing(GameObject player){
		player.GetComponent<PlayerUpgrades>().EquipRunningShoes();
		Dialog.Instance.UpdateDialog(conversationText);
		Timer.Instance.ReduceTime(20);
		this.gameObject.SetActive(false);
	}
}
