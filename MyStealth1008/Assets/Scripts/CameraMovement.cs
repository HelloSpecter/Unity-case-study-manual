using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float smooth = 10f;
    public float ss = 2;
    private Transform player;
    private Vector3 relCameraPos;
    private float relCameraPosMag;
    private Vector3 newPos;
    private LiftUp liftUp;

    void Awake()
    {
        player = GameObject.FindWithTag(Tags.Player).transform;
        relCameraPos = transform.position - player.position;
        relCameraPosMag = relCameraPos.magnitude - 0.5f;
        liftUp = GameObject.Find("prop_lift_exit").GetComponent<LiftUp>();
    }
    

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}
    void FixedUpdate()
    {
        Vector3 standardPos = player.position + relCameraPos;
        Vector3 abovePos = player.position + Vector3.up * relCameraPosMag;
        Vector3[] checkPoints = new Vector3[5];
        if (!liftUp.playerIn)
        {
            checkPoints[0] = standardPos;
            checkPoints[1] = Vector3.Lerp(standardPos, abovePos, 0.25f);
            checkPoints[2] = Vector3.Lerp(standardPos, abovePos, 0.5f);
            checkPoints[3] = Vector3.Lerp(standardPos, abovePos, 0.75f);
            checkPoints[4] = abovePos;
        }
        else
        {
            newPos = player.position + 2 * relCameraPos - Vector3.forward*ss;
        }
        for (int i = 0; i < checkPoints.Length; i++)
        {
            if (ViewingPositionCheck(checkPoints[i]))
            {
                break;
            }

        }
        transform.position = Vector3.Lerp(transform.position, newPos, smooth * Time.deltaTime);
        //transform.position = newPos;
        SmoothLookAt();
    }
    bool ViewingPositionCheck(Vector3 checkPos)
    {
        RaycastHit hit;
        //if (Physics.Raycast(checkPos,player.position-checkPos,out hit,relCameraPosMag))
        if (Physics.Raycast(checkPos, player.position - checkPos, out hit))
        {
            if (hit.transform != player)
            {
                return false;
            }

           

        }
        newPos = checkPos;
        return true;
    }

    void SmoothLookAt()
    {
        Vector3 relPlayerPosition = player.position - transform.position;
        Quaternion lookAtRotation = Quaternion.LookRotation(relPlayerPosition, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookAtRotation, Time.deltaTime * smooth);
        //transform.rotation = lookAtRotation;//人物反向超过相机投影位置时，会跳变
    }
}
