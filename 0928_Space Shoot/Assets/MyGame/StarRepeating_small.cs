using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRepeating_small : MonoBehaviour
{
    public float speed = 0.13f;
    private Vector3 StartPosition = new Vector3(0, 0, -3.44f);
    private float zNow;
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = StartPosition;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        zNow = transform.localPosition.z;

        if (Mathf.Abs(zNow - (-10.75f)) < 0.01f)
        {
            transform.localPosition = StartPosition;
        }
    }
}
