﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectable : MonoBehaviour, ICollectable {

	public int scoreValue;

	private Scorekeeper scorekeeper;

	void Start(){
		scorekeeper = (Scorekeeper)GameObject.FindObjectOfType(typeof(Scorekeeper));
	}

	public void DoTheThing(GameObject player){
		if (scorekeeper != null){
			scorekeeper.UpdateScore(scoreValue);
		}
		Destroy(this.gameObject);
	}
}
