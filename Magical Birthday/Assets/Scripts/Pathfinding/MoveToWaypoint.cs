using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToWaypoint : MonoBehaviour {

	public float speed;
	public bool rotation = true;

	private Transform targetWaypoint;
	private Transform nextWaypoint;
	private bool isWalking;

	void Start () {
		targetWaypoint = WaypointManager.Instance.FindNearestWaypoint(transform);
		isWalking = true;
	}

	void Update () {
		if (!isWalking){
			return;
		}
		float step =  speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, step);

		if (rotation){
			Vector3 targetDir = (targetWaypoint.position - transform.position).normalized;
			var rot = Mathf.Atan2(targetDir.x, targetDir.y) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(rot, Vector3.back);
		}

		if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.001f)
		{
			nextWaypoint = targetWaypoint.GetComponent<Waypoint>().GetNextWaypoint();
			targetWaypoint = nextWaypoint;
		}
	}

	public void IsWalking(bool isWalking){
		this.isWalking = isWalking;
	}
}
