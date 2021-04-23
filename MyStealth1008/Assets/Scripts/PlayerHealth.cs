﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    public float resetAfterDeathTime = 5f;
    public AudioClip deathClip;
    private Animator anim;
    private PlayerMovement playerMovement;
    private HashIDs hash;
    private SceneFadeInOut sceneFadeInOut;
    private LastPlayerSighting lastPlayerSighting;
    private float timer;
    private bool playerDead;
    //public  bool playerDead;
    void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        hash = GameObject.FindWithTag(Tags.GameController).GetComponent<HashIDs>();
        sceneFadeInOut = GameObject.FindWithTag(Tags.Fader).GetComponent<SceneFadeInOut>();
        lastPlayerSighting = GameObject.FindWithTag(Tags.GameController).GetComponent<LastPlayerSighting>();
    }


    void Start()
    {


    }
	void Update ()
    {
        if (health<=0f)
        {
            if (!playerDead)
            {
                PlayerDying();
            }
            else
            {
                PlayerDead();
                LevelReset();
            }
        }

	}
    void PlayerDying()
    {
        playerDead = true;
        anim.SetBool(hash.deadBool, playerDead);
        AudioSource.PlayClipAtPoint(deathClip, transform.position);

    }
    void PlayerDead()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).fullPathHash==hash.dyingState)
        {
            anim.SetBool(hash.deadBool, false);
        }
        anim.SetFloat(hash.speedFloat, 0f);
        playerMovement.enabled = false;
        lastPlayerSighting.position = lastPlayerSighting.resetPosition;
        GetComponent<AudioSource>().Stop();

    }
    void LevelReset()
    {
        timer += Time.deltaTime;
        if (timer>=resetAfterDeathTime)
        {
            sceneFadeInOut.EndScene();
            sceneFadeInOut.IsGameOver = true;
        }
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
    }
}
