using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_planet : MonoBehaviour
{
    public float speed = 0.2f;
    private Vector3 StartPosition = new Vector3(0, 0, 3.7f);
    private float zNow;
    // Start is called before the first frame update
    void Start()
    {
        //transform.localPosition = StartPosition;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed,Space.World);
        zNow = transform.localPosition.z;

        if (Mathf.Abs(zNow - (-9.53f)) < 0.01f)
        {
            transform.localPosition = StartPosition;
        }
    }
}
