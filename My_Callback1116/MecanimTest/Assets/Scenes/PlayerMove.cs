using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    // Use this for initialization
    public float MoveSpeed = 5.0f;
    public float jumpSpeed = 10f;
    public float gravity = 9.8f;
    CharacterController cc;
    Vector3 pos;
    Vector3 pos1;
    public float pushPower = 3.0f;

    void Start () {
        cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        
        
            pos = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            pos = transform.TransformDirection(pos);
            //cc.SimpleMove(MoveSpeed * pos);
            pos.x *= MoveSpeed;
            pos.z *= MoveSpeed;

        if (Input.GetButton("Jump")&& cc.isGrounded)
            {
                pos1.y = jumpSpeed;
            }

        if (!cc.isGrounded)
        {
            pos1.y -= gravity * Time.deltaTime;
        }
        cc.Move((pos+pos1) * Time.deltaTime);

	}
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body==null||body.isKinematic)
        {
            return;
        }
        if (hit.moveDirection.y<-0.3f)
        {
            return;
        }
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        body.velocity = pushDir * pushPower;
    }
}
