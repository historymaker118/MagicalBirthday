using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrades : MonoBehaviour {

	public GameObject hamsterball;
	public GameObject runningShoes;

	private bool immune;
	private bool superspeed;

	void Start () {
		immune = false;
		superspeed = false;
		hamsterball.SetActive(false);
		runningShoes.SetActive(false);
	}

	public void EquipHamsterBall(){
		hamsterball.SetActive(true);
		immune = true;
	}

	public void EquipRunningShoes(){
		runningShoes.SetActive(true);
		superspeed = true;
	}

	public bool HasImmunity(){
		return immune;
	}

	public bool HasSuperspeed(){
		return superspeed;
	}
}
