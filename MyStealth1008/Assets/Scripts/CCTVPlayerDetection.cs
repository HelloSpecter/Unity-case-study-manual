using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTVPlayerDetection : MonoBehaviour 
{

	private GameObject player;
	private LastPlayerSighting lastPlayerSighting;
	void Start () 
	{
		player = GameObject.FindWithTag(Tags.Player);
		lastPlayerSighting = GameObject.FindWithTag(Tags.GameController).GetComponent<LastPlayerSighting>();
	}
	
	void Update () 
	{
		
	}
	void OnTriggerStay(Collider other)
    {
        if (other.gameObject==player)
        {
			Vector3 relPlayerPos = player.transform.position - transform.position;
			RaycastHit hit;
            if (Physics.Raycast(transform.position,relPlayerPos,out hit))
            {
                if (hit.transform.gameObject==player)
                {
					lastPlayerSighting.position = player.transform.position;
                }
            }
        }
    }

}
