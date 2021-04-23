using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    float turnSpeed = 10.0f;
    float sensitivity = 1.0f;
    float forwardForce = 50.0f;
    private float maxTurnLean = 50.0f;
    private float maxTilt = 50.0f;
    private float normalizedSpeed = .2f;
    private Vector3 euler = Vector3.zero;
    public  Transform guiSpeedElement;
    // Use this for initialization
	void Start () {
        Screen.orientation = ScreenOrientation.AutoRotation;
        guiSpeedElement.position = new Vector3(30, normalizedSpeed * Screen.height, 0);
	}
	
	// Update is called once per frame
	void Update () {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase==TouchPhase.Moved)
            {
                normalizedSpeed = touch.position.y / Screen.height;
                guiSpeedElement.position = new Vector3(30, touch.position.y, 0);
            }
        }
	}
    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddRelativeForce(0, 0, normalizedSpeed * forwardForce);
        Vector3 acc = Input.acceleration;
        euler.y += acc.x * turnSpeed;
        euler.z = Mathf.Lerp(euler.z, -acc.x * maxTurnLean, 0.2f);
        euler.x = Mathf.Lerp(euler.x, acc.y * maxTilt, 0.2f);
        Quaternion rot = Quaternion.Euler(euler);
        transform.rotation=Quaternion.Lerp(transform.rotation, rot, sensitivity);
    }
}
