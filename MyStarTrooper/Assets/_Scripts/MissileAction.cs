using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileAction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward) * 200.0f);
        //GetComponent<Rigidbody>().AddForce(transform.forward * 200.0f);

    }
    public  GameObject explosion;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag!="missile")
        {

        
        ContactPoint contact = collision.contacts[0];
        GameObject exp = Instantiate(explosion, contact.point + (contact.normal * 5.0f), Quaternion.identity);
        if (collision.gameObject.tag=="enemy")
        {
            Destroy(collision.gameObject);
        }
        Destroy(exp, 2.0f);
        Destroy(gameObject);
        }
    }
    
}
