using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprinkler : MonoBehaviour {

    private float heightAboveFloor;
    private ParticleSystem[] sprinklers;
    private List<List<ParticleCollisionEvent>> collisionEvents;
    private GameObject barrel;
    private Fire fire;
    private void Awake()
    {
        sprinklers = GetComponentsInChildren<ParticleSystem>();

    }
    // Use this for initialization
    void Start () {
        heightAboveFloor = transform.position.y;
        collisionEvents = new List<List<ParticleCollisionEvent>>();
        for (int i = 0; i < sprinklers.Length; i++)
        {
            collisionEvents.Add(null);//初始化
        }
        barrel = GameObject.FindWithTag("FireBarrel");
        fire = barrel.GetComponent<Fire>();
		
	}
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits;
            hits = Physics.RaycastAll(ray);
            foreach (RaycastHit h in hits)
            {
                if (h.collider.name=="ground")
                {
                    transform.position = h.point + new Vector3(0f, heightAboveFloor, 0f);
                    //Debug.Log("Hit at:"+h.point);
                }
                

            }
            if (!sprinklers[0].isPlaying)
            {
                for (int i = 0; i < sprinklers.Length; i++)
                {
                    sprinklers[i].Play();
                }
            }

        }
        else
        {
            if (sprinklers[0].isPlaying)
            {
                for (int i = 0; i < sprinklers.Length; i++)
                {
                    sprinklers[i].Stop();
                }
            }
        }
	}
    void OnParticleCollision(GameObject other)
    {
        if (other.tag=="FireBarrel")
        {
            for (int i = 0; i < sprinklers.Length; i++)
            {
                collisionEvents[i] = new List<ParticleCollisionEvent>(sprinklers[i].GetSafeCollisionEventSize());
            }
            for (int i = 0; i < sprinklers.Length; i++)
            {
                sprinklers[i].GetCollisionEvents(gameObject, collisionEvents[i]);
            }
            for (int i = 0; i < sprinklers.Length; i++)
            {
                for (int j = 0; j < collisionEvents[i].Capacity; j++)
                {
                    foreach (ParticleHelper ph in fire.particles)
                    {
                        if (ph.varyAlpha)
                        {
                            ph.DecreaseAlpha();
                        }
                        if (ph.varyEmission)
                        {
                            ph.DecreaseEmission();
                        }
                        if (ph.varyIntensity)
                        {
                            ph.DecreaseIntensity();
                        }
                        if (ph.varyRange)
                        {
                            ph.DecreaseRange();
                        }
                    }
                }
            }
        }
    }
}
