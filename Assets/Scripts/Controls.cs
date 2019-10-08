using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
private CharacterController _charController;

	[SerializeField]
	GameObject go;
	[SerializeField]
	GameObject gameob;
	public float speed = 1.0f;
	public float gravity = -9.8f;
	public float speedRot = 15.0f;
	private Vector3 moveDirection = Vector3.zero;
	private float _rotY;
	private TrailRenderer _tr;
	private Camera cam;



	void Start()
	{
		_charController = GetComponent<CharacterController>();
		_rotY = transform.eulerAngles.y;
		_tr = go.GetComponent < TrailRenderer>();
		cam = gameob.GetComponent<Camera>();
	}

	void Update()
	{
		float posZ = Input.GetAxis("Vertical");
		if (_charController.isGrounded)
		{
			moveDirection = new Vector3(0, 0, posZ);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
		}
		moveDirection.y = gravity * Time.deltaTime;
		_charController.Move(moveDirection * Time.deltaTime);
		float horInput = Input.GetAxis("Horizontal");
		if (horInput != 0)
		{
			transform.Rotate(0, horInput * speedRot * Time.deltaTime, 0);
		}
		if (Input.GetButtonUp("Cancel"))
		{
			Application.Quit();
		}
		if (Input.GetKey("f"))
		{
			_tr.enabled = true;
		}
		if (Input.GetKey("r"))
		{
			_tr.enabled = false;
			_tr.Clear();
		}
		if (Input.GetKey("e"))
		{
			cam.enabled = true;
		}
		if (Input.GetKey("q"))
		{
			cam.enabled = false;
		}

	}
}
	