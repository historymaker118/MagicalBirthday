using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour {

	public static WaypointManager Instance;

	public List<Transform> waypointList;

	void Awake () {
		if (Instance == null){
			Instance = this;
		}
	}

	public Transform FindNearestWaypoint(Transform npcTransform){
		Transform bestOption = waypointList[0];
		float bestDistance = float.MaxValue;
		foreach (Transform waypoint in waypointList){
			float distance = Vector3.Distance(npcTransform.position, waypoint.position);
			if (distance < bestDistance){
				bestDistance = distance;
				bestOption = waypoint;
			}
		}
		return bestOption;
	}

}
