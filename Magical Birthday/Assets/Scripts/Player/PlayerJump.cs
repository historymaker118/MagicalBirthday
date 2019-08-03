using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

	public Animator player;

	void Update () {
		if (Input.GetButtonDown("Jump")){
			player.SetTrigger("Jump");
		}
	}
}
