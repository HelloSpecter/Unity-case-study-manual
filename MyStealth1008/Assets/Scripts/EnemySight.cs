using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySight : MonoBehaviour {
	public float fieldOfViewAngle = 110f;
	public bool playerInSight;
	public Vector3 personalLastSighting;//敌人对象观察到Player对象的最后位置
	private NavMeshAgent nav;
	private SphereCollider col;
	private Animator anim;
	private LastPlayerSighting lastPlayerSighting;
	private GameObject player;
	private Animator playerAnim;
	private PlayerHealth playerHealth;
	private HashIDs hash;
	private Vector3 previousSighting;//上一帧中Player对象被观察到的位置

	void Awake()
    {
		nav = GetComponent<NavMeshAgent>();
		col = GetComponent<SphereCollider>();
		anim = GetComponent<Animator>();
		lastPlayerSighting = GameObject.FindWithTag(Tags.GameController).GetComponent<LastPlayerSighting>();
		player = GameObject.FindWithTag(Tags.Player);
		playerAnim = player.GetComponent<Animator>();
		playerHealth = player.GetComponent<PlayerHealth>();
		hash = GameObject.FindWithTag(Tags.GameController).GetComponent<HashIDs>();
		personalLastSighting = lastPlayerSighting.resetPosition;
		previousSighting = lastPlayerSighting.resetPosition;

	}
	float CalculatePathLength(Vector3 targetPosition)
    {
		NavMeshPath path = new NavMeshPath();
        if (nav.enabled)
        {
			nav.CalculatePath(targetPosition,path);//代码原型：public bool CalculatePath(Vector3 targetPosition,NavMeshPath path);
        }
		Vector3[] allWayPoints = new Vector3[path.corners.Length + 2];
		allWayPoints[0] = transform.position;
		allWayPoints[allWayPoints.Length - 1] = targetPosition;
        for (int i = 0; i < path.corners.Length; i++)
        {
			allWayPoints[i + 1] = path.corners[i];
		}
		float pathLength = 0;
        for (int i = 0; i < allWayPoints.Length-1; i++)
        {
			pathLength += Vector3.Distance(allWayPoints[i], allWayPoints[i + 1]);
        }
		return pathLength;
    }

	void Start () {

		
	}
	
	void Update () 
	{
        if (lastPlayerSighting.position !=previousSighting)
        {
			personalLastSighting = lastPlayerSighting.position;

        }
		previousSighting = lastPlayerSighting.position;
        if (playerHealth.health>0f)
        {
			anim.SetBool(hash.playerInSightBool, playerInSight);
        }
        else
        {
			anim.SetBool(hash.playerInSightBool, false);
        }
	}
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject==player)
        {
            playerInSight = false;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject==player)
        {
			playerInSight = false;
			Vector3 direction = other.transform.position - transform.position;
			float angle = Vector3.Angle(direction, transform.forward);
            if (angle<fieldOfViewAngle*0.5f)
            {
				RaycastHit hit;
                if (Physics.Raycast(transform.position+transform.up,direction.normalized,out hit,col.radius))
                {
                    if (hit.collider.gameObject==player)
                    {
						playerInSight = true;
						lastPlayerSighting.position = player.transform.position;
                    }

                }
            }
			int state0 = playerAnim.GetCurrentAnimatorStateInfo(0).fullPathHash;
			int state1 = playerAnim.GetCurrentAnimatorStateInfo(1).fullPathHash;
            if (state0==hash.locomotionState||state1==hash.shoutState)
            {
				if (CalculatePathLength(player.transform.position)<=col.radius)
                {
					personalLastSighting = player.transform.position;
                }
            }
		}
	}
}
