using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	//must be between 0 and 1
	[Range(0, 1)]
	public float smoothSpeedZ = 0.125f;
	public float smoothSpeedY = 3f;
	public bool hasSmoothing;
	public Vector3 offset;
	public Vector3 exteriorRotation;
	public Vector3 interiorOffset;
	public Vector3 interiorRotation;
	public float tiltSpeed = 0.001f;

	public bool IsInside { get; set; }

	private Vector3 targetOffset;
	private Vector3 targetRotation;

	private bool isSmoothing;

	void Start(){
		IsInside = false;
		isSmoothing = false;
		targetOffset = offset;
		targetRotation = exteriorRotation;
	}

	void LateUpdate(){
		Vector3 desiredPosition = target.position + targetOffset;

		if (isSmoothing){
			float smoothedPositionZ = Mathf.Lerp(transform.position.z, desiredPosition.z, smoothSpeedZ * Time.deltaTime);
			float smoothedPositionY = Mathf.Lerp(transform.position.y, desiredPosition.y, smoothSpeedY * Time.deltaTime);
			Vector3 newPos = new Vector3(desiredPosition.x, smoothedPositionY, smoothedPositionZ);
			transform.position = newPos;
			//transform.LookAt(target);
		} else {
			transform.position = desiredPosition;
		}
	}

	private IEnumerator RotateCamera(){
		bool check = false;
		if (IsInside){
			targetOffset = interiorOffset;
			targetRotation = interiorRotation;
			while(transform.localRotation.eulerAngles.x <= targetRotation.x - 0.001f) {
				isSmoothing = true;
				transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRotation), tiltSpeed * Time.deltaTime);
				yield return null;
			}
		} else {
			targetOffset = offset;
			targetRotation = exteriorRotation;
			while(transform.localRotation.eulerAngles.x >= targetRotation.x + 0.001f) {
				isSmoothing = true;
				transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRotation), tiltSpeed * Time.deltaTime);
				yield return null;
			}
		}

		transform.rotation = Quaternion.Euler(targetRotation);
		isSmoothing = false;
		yield return null;
	}

	public void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Exterior"){
			IsInside = false;
			StopCoroutine(RotateCamera());
			StartCoroutine(RotateCamera());
		}
	}

	public void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Exterior"){
			IsInside = true;
			StopCoroutine(RotateCamera());
			StartCoroutine(RotateCamera());
		}
	}
}
