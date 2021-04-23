using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftUp : MonoBehaviour {
	SceneFadeInOut sceneFadeInOut;
	ExitDoor exitDoor;
	float liftSpeed = 1.0f;
	Transform exitLeftDoor;
	Rigidbody rig;
	float wait = 50;
    float temp = 0, temp2 = 0;
	public bool playerIn = false;
    float waitTime = 2.0f;
    PlayerInventory playerInventory;




    void Awake()
    {
		sceneFadeInOut = GameObject.FindWithTag(Tags.Fader).GetComponent<SceneFadeInOut>();
		exitDoor= GameObject.Find("door_exit_inner").GetComponent<ExitDoor>();
		exitLeftDoor = GameObject.Find("door_exit_inner").transform.Find("door_exit_inner_left_001");
		rig = GetComponent<Rigidbody>();
        //Debug.LogError(rig.constraints);
        rig.constraints = RigidbodyConstraints.FreezeAll;//锁定电梯的轴，避免它乱折腾引发BUG
        playerInventory =GameObject.FindWithTag(Tags.Player).GetComponent<PlayerInventory>();



    }
    void Start () {
		
	}
	

	void Update () {
		
	}
    private void FixedUpdate()
    {
        
        if (!playerIn)
        {
            temp2 = Time.time;
        }
        if (playerIn)
        {
            rig.MovePosition(rig.position + transform.up * Time.deltaTime * liftSpeed);
            if (Time.time-temp2>waitTime)
            {
                sceneFadeInOut.EndScene();
            }
            rig.constraints = (RigidbodyConstraints)122;//打开电梯的Y轴，其他锁定，确保垂直上升

        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject==GameObject.FindWithTag(Tags.Player))
        {
            if (Mathf.Abs(exitLeftDoor.position.magnitude-exitDoor.leftOld.magnitude)<0.01f)
            {
				temp++;
                if (temp>wait&& playerInventory.hasKey)
                {
					playerIn = true;
                   
					//rb.MovePosition(transform.position + transform.forward * Time.deltaTime)
				}


			}
		}
    }
}
