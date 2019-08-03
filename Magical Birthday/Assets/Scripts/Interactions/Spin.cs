using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

	public Vector3 spinAmount;

	void Update () {
		transform.Rotate(spinAmount);
	}
}
