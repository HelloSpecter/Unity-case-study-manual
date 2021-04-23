using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet : MonoBehaviour
{
    public float bulletSpeed = 6.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.Translate(new Vector3(0, 0, 1)*Time.deltaTime*bulletSpeed, Space.World);
        //if (transform.localPosition.z>3.3f)
        //{
        //    Destroy(gameObject);
        //}
    }
}
