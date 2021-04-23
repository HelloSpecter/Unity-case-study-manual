using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public int particleSize;
    public ParticleSystem particle;

    // Use this for initialization
    void Start () {
        particle = GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {


    }
    void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.tag);
        List<ParticleCollisionEvent> collisionEvents;
        particleSize = particle.GetSafeCollisionEventSize();
        collisionEvents=new List<ParticleCollisionEvent>(particleSize);
        int num = particle.GetCollisionEvents(other,collisionEvents);
        for (int i = 0; i < num; i++)
        {
            ParticleCollisionEvent pt = collisionEvents[i];
            Vector3 pos = pt.intersection;
            if (pt.colliderComponent.tag == "Cube")
            {
                Debug.Log("hit Cube at:" + pos);
            }
            else if (pt.colliderComponent.tag == "Capsule")
            {
                Debug.Log("hit Capsule at:" + pos);
            }
            else if (pt.colliderComponent.tag == "Sphere")
            {
                Debug.Log("hit Sphere at:" + pos);
            }
        }
    }
    

}
