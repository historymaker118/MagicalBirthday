using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagCheckpoint : MonoBehaviour, ICheckpoint {

	public void DoTheThing(bool thing){
		GameManager.Instance.TriggerGameOver();
	}
}
