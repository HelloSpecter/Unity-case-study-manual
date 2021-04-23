using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundRepeating : MonoBehaviour
{
    public float speed = 0.1f;
    private Vector3 StartPosition=new Vector3(0,0,5.96f);
    private float zNow;
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition =StartPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.down*Time.deltaTime*speed);
        zNow = transform.localPosition.z;

        if (Mathf.Abs(zNow-(-1.98f))<0.01f)
        {
            transform.localPosition = StartPosition;
        }
    }

}
