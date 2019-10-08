using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : MonoBehaviour
{
	private CharacterController _charController;


	public float speed = 1.0f;
	public float gravity = -9.8f;
	private Vector3 moveDirection = Vector3.zero;

	void Start()
	{
		_charController = GetComponent<CharacterController>();
	}
	RaycastHit hit;
	RaycastHit hit2;
    void Update()
    {
		if (_charController.isGrounded)
		{
			moveDirection = Vector3.forward;
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
		}

		transform.Translate(1, 1, 1);
		moveDirection.y = gravity * Time.deltaTime;
		_charController.Move(moveDirection * Time.deltaTime);
		if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1) && Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit2, Mathf.Infinity))
		{
			transform.Rotate(new Vector3(0, -90, 0));
		}
		if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit2, 1.5f))
		{
			transform.Rotate(new Vector3(0, 90, 0));
			transform.Translate(0.25f*Time.deltaTime, 0, 0);
			transform.Translate(0, 0, 1f);

		}
    }

}
