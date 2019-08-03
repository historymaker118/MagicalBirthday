using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

	public List<Transform> neighbouringWaypoints;

	public Transform GetNextWaypoint(){
		int rand = Random.Range(0, neighbouringWaypoints.Count);
		return neighbouringWaypoints[rand];
	}
}
