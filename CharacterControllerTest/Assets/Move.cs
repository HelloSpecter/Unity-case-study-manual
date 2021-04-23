using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
	public float speed = 5.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	public float pushPower = 2.0f;

	CharacterController cc;
	Vector3 moveDir = Vector3.zero;

	void Start ()
	{
		cc = GetComponent<CharacterController>();
	}

	void Update ()
	{
		if(cc.isGrounded)
		{
			moveDir = new Vector3(Input.GetAxis("Horizontal"), 0,
								Input.GetAxis("Vertical"));
			moveDir = transform.TransformDirection(moveDir);
			moveDir *= speed;

			if(Input.GetButton("Jump"))
				moveDir.y = jumpSpeed;
		}

		moveDir.y -= gravity * Time.deltaTime;
		cc.Move(moveDir * Time.deltaTime);
	}

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		Rigidbody body = hit.collider.attachedRigidbody;
		if(body == null || body.isKinematic)
			return;
		if(hit.moveDirection.y < -0.3f)
			return;

		Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
		body.velocity = pushDir * pushPower;
	}
}
