﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour 
{
	public float deadZone = 5f;
	private Transform player;
	private EnemySight enemySight;
	private NavMeshAgent nav;
	private Animator anim;
	private HashIDs hash;
	private SimpleLocomotion locomotion;

	void Awake()
    {
		player = GameObject.FindWithTag(Tags.Player).GetComponent<Transform>();
		enemySight = GetComponent<EnemySight>();
		nav = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
		hash = GameObject.FindWithTag(Tags.GameController).GetComponent<HashIDs>();
		nav.updateRotation = false;
		locomotion = new SimpleLocomotion(anim, hash);
		anim.SetLayerWeight(1, 1f);
		anim.SetLayerWeight(2, 1f);
		deadZone *= Mathf.Deg2Rad;

    }


	void OnAnimatorMove()
    {
		nav.velocity = anim.deltaPosition / Time.deltaTime;
		transform.rotation = anim.rootRotation;
    }


	float FindAngle(Vector3 fromVector, Vector3 toVector, Vector3 upVector)
    {
        if (toVector==Vector3.zero)
        {
			return 0f;
        }
		float angle = Vector3.Angle(fromVector, toVector);
		Vector3 normal = Vector3.Cross(fromVector, toVector);
		angle *= Mathf.Sign(Vector3.Dot(normal, upVector));
		angle *= Mathf.Deg2Rad;
		return angle;
    }
	void NavAnimSetup()
    {
		float speed;
		float angle;
        if (enemySight.playerInSight)
        {
			speed = 0f;
			angle = FindAngle(transform.forward, player.position - transform.position, transform.up);
        }
        else
        {
			speed = Vector3.Project(nav.desiredVelocity, transform.forward).magnitude;
			angle = FindAngle(transform.forward, nav.desiredVelocity, transform.up);
            if (Mathf.Abs(angle)<deadZone)
            {
				transform.LookAt(transform.position + nav.desiredVelocity);
				angle = 0f;
            }
        }
		locomotion.Do(speed, angle);

	}
	void Start () 
	{
		
	}
	
	void Update () 
	{
        NavAnimSetup();
	}
}
