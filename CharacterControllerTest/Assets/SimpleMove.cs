using UnityEngine;
using System.Collections;

public class SimpleMove : MonoBehaviour
{
	CharacterController cc;
	public float speed = 5.0f;
	Vector3 moveDir = Vector3.zero;
	void Start ()
	{
		cc = GetComponent<CharacterController>();
	}

	void Update ()
	{
		//if(cc.isGrounded)
		{
			moveDir = new Vector3(Input.GetAxis("Horizontal"), 0,
								Input.GetAxis("Vertical"));
			moveDir = transform.TransformDirection(moveDir);
			cc.SimpleMove(speed * moveDir);
		}
	}
}
