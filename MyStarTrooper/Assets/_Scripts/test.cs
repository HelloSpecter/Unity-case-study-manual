using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    private void OnGUI()
    {
        GUI.Box(new Rect(5,30,100,50),string.Format("{0:0.00}",Input.acceleration.x));
        GUI.Box(new Rect(5, 85, 100, 50), string.Format("{0:0.00}", Input.acceleration.y));
        GUI.Box(new Rect(5, 140, 100, 50), string.Format("{0:0.00}", Input.acceleration.z));

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
