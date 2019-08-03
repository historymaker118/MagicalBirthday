using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementXZ : MonoBehaviour {

	public Animator animator;

	[SerializeField, Range(0.1f, 10.0f)]
	private float moveSpeed;

	[SerializeField, Range(1.0f, 100.0f)]
	private float rotationSmoothing = 10.0f;

	private bool canMove;

	new private Rigidbody2D rigidbody;

	void Start()
	{
		canMove = true;
		rigidbody = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		if (!canMove || !GameManager.Instance.IsGameRunning){
			return;
		}
		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

		rigidbody.MovePosition((Vector2)transform.position + input * Time.deltaTime * moveSpeed);
		
		// Rotate the avatar in the direction of movement
		if(input.sqrMagnitude > 0.2f)
		{

			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0.0f, 0.0f, Mathf.Atan2(-input.x, input.y) * Mathf.Rad2Deg), Time.deltaTime * rotationSmoothing);
		}

		//animator.SetFloat("MoveSpeed", input.magnitude);
	}

	public void ToggleMovement(bool canMove){
		this.canMove = canMove;
	}
}
