using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    public float bulletSpeed = 6.0f;
    float ds;

    // Start is called before the first frame update
    void Start()
    {
        ds = Random.Range(-0.2f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.Translate(new Vector3(ds, 0, -1) * Time.deltaTime * bulletSpeed, Space.World);
    }
}
