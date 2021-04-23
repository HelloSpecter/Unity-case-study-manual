using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelLid : MonoBehaviour {

    public float dropletForce;
    public Rigidbody lid;
    private ParticleSystem[] sprinklers;
    //private List<ParticleCollisionEvent>[] collisionEvents;
    private List<List<ParticleCollisionEvent>> collisionEvents;

    // Use this for initialization
    void Awake()
    {
        sprinklers = GetComponentsInChildren<ParticleSystem>();
    }
    void Start ()
    {
        Debug.Log(sprinklers.Length.ToString());
        collisionEvents = new List<List<ParticleCollisionEvent>>();
        for (int i = 0; i < sprinklers.Length; i++)
        {
            collisionEvents.Add(null);//有没有更好的初始化方法
        }
        Debug.Log(collisionEvents.Capacity);

    }

    // Update is called once per frame
    void Update () {
		
	}
    private void OnParticleCollision(GameObject other)
    {
        if (collisionEvents==null)
        {
            return;
        }
        if (other.tag=="Barrel")
        {
            for (int i = 0; i < sprinklers.Length; i++)
            {
                collisionEvents[i] = new List<ParticleCollisionEvent>(sprinklers[i].GetSafeCollisionEventSize());//初始化
            }
            for (int i = 0; i < sprinklers.Length; i++)
            {
                sprinklers[i].GetCollisionEvents(other, collisionEvents[i]);
                if (collisionEvents[i]!=null)
                {
                    Debug.Log("collisionEvents" + i + "Get");
                }
            }
            for (int i = 0; i < sprinklers.Length; i++)
            {
                for (int j = 0; j < collisionEvents[i].Capacity; j++)
                {
                    lid.AddForceAtPosition(Vector3.down * dropletForce, collisionEvents[i][j].intersection);
                }
            }
        }
    }

}
