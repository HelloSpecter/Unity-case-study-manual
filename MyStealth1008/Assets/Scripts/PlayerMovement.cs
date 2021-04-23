using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AudioClip shoutingClip;
    public float turnSmoothing = 15f;
    public float speedDampTime = 0.1f;
    private Animator animator;
    private HashIDs hash;

    //修改
    //private Quaternion PlayerQuaternion;

    void Awake()
    {
        animator = GetComponent<Animator>();
        hash = GameObject.FindWithTag(Tags.GameController).GetComponent<HashIDs>();
        animator.SetLayerWeight(1, 1f);
    }
    void Rotating(float h,float v)
    {

        Vector3 targetDir = new Vector3(h, 0, v);
        Quaternion targetRotation = Quaternion.LookRotation(targetDir, Vector3.up);
        Rigidbody r = GetComponent<Rigidbody>();
        Quaternion newRotation = Quaternion.Lerp(r.rotation, targetRotation, turnSmoothing * Time.deltaTime);
        r.MoveRotation(newRotation);
        //r.rotation = Quaternion.Lerp(r.rotation, targetRotation, turnSmoothing * Time.deltaTime);

    }
    void MovementManagement(float h,float v,bool sneaking)
    {

    
        animator.SetBool(hash.sneakingBool, sneaking);

        if (v!=0||h!=0)
        {
             Rotating(h, v);

            animator.SetFloat(hash.speedFloat, 5.5f, speedDampTime, Time.deltaTime);
        }
        //else if (v<0)
        //{
        //    transform.forward = -transform.forward;
        //}
        //if (h==0&&v!=0)
        //{
        //    Rotating(h, v);

        //    animator.SetFloat(hash.speedFloat, 5f, speedDampTime, Time.deltaTime);
        //}
        //if (h != 0 && v !=0)
        //{
        //    Rotating(h, v);
        //    //Rotating(h, v);
        //    animator.SetFloat(hash.speedFloat, 5f,speedDampTime,Time.deltaTime);

        //}
        //if (h!=0&&v==0)
        //{
        //    Rotating(h, v);
        //    animator.SetFloat(hash.speedFloat, 5f);
        //}
        //if (h!=0)
        //{
        //    Rotating(h, v);
        //    animator.SetFloat(hash.speedFloat, 1.0f, speedDampTime, Time.deltaTime);

        //}
        else
        {
            animator.SetFloat(hash.speedFloat, 0f);
        }
    }

	void Start ()
    {
		
	}
	
	
	void Update ()
    {
        bool shout = Input.GetButtonDown("Attract");
        animator.SetBool(hash.shoutingBool, shout);
        AudioManagement(shout);
	}
    void FixedUpdate()
    {
       
        //PlayerQuaternion = Quaternion.FromToRotation(Vector3.forward, transform.forward);
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        bool sneak = Input.GetButton("Sneak");
        MovementManagement(h, v, sneak);
    }

    void AudioManagement(bool shout)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (animator.GetCurrentAnimatorStateInfo(0).fullPathHash==hash.locomotionState)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            
        }
        else audioSource.Stop();
        if (shout)
        {
            AudioSource.PlayClipAtPoint(shoutingClip, transform.position);
        }
    }
}
