using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCheckpoint : MonoBehaviour, IHazard {

	public string conversationText;

	public void DoTheThing(GameObject player){
		Dialog.Instance.UpdateDialog(conversationText);
	}
}
