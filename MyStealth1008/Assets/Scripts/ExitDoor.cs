using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour {
    public bool requireKey;
    public AudioClip doorSwitchClip;
    public AudioClip accessDeniedClip;
    //private Animator anim;
    //private HashIDs hash;
    private GameObject player;
    private PlayerInventory playerInventory;
    public  int count;
    private bool doorOpen = false;
    private Transform leftDoor, rightDoor;
    [HideInInspector] public  Vector3 leftOld;
    private Vector3 rightOld;
    private float  doorSpeed=4f;
    LiftUp liftUp;


    void Awake()
    {
        //anim = GetComponent<Animator>();
        //hash = GameObject.FindWithTag(Tags.GameController).GetComponent<HashIDs>();
        player = GameObject.FindWithTag(Tags.Player);
        playerInventory = player.GetComponent<PlayerInventory>();
        leftDoor = transform.Find("door_exit_inner_left_001");
        rightDoor = transform.Find("door_exit_inner_right_001");
        leftOld = leftDoor.position;
        rightOld = rightDoor.position;
        liftUp = GameObject.Find("prop_lift_exit").GetComponent<LiftUp>();

    }
    void OnTriggerEnter(Collider other)
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (other.gameObject == player)
        {
            if (requireKey)
            {
                if (playerInventory.hasKey)
                {
                    count++;
                }
                else
                {
                    audio.clip = accessDeniedClip;//Play the music "Can't Enter!"
                    audio.Play();
                }
            }
            else
            {
                count++;
            }
        }
        else if (other.gameObject.tag == Tags.Enemy)
        {
            if (other is CapsuleCollider)
            {
                count++;
            }
        }

    }
    void Update()
    {
        
        if (!liftUp.playerIn)
        {

        
        if (count>0)
        {
            doorOpen = true;
        }
        AudioSource audio = GetComponent<AudioSource>();
        if (doorOpen&&!audio.isPlaying& Mathf.Abs(leftDoor.position.magnitude - leftOld.magnitude) < 0.01f)
        {
            audio.clip = doorSwitchClip;
            audio.Play();
        }
        switchDoor();
        if (Mathf.Abs(leftDoor.position.magnitude-((leftOld+ transform.forward * 2).magnitude))<0.01f)
        {
            doorOpen = false;
        }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player || (other.gameObject.tag == Tags.Enemy && other is CapsuleCollider))
        {
            count = Mathf.Max(0, count - 1);
        }
    }
    void switchDoor()
    {
        if (doorOpen)
        {
            leftDoor.position = Vector3.Lerp(leftDoor.position, leftOld + transform.forward*2, doorSpeed * Time.deltaTime);
            rightDoor.position = Vector3.Lerp(rightDoor.position, rightOld + transform.forward * -2, doorSpeed * Time.deltaTime);

        }
        else if (!doorOpen)
        {
            leftDoor.position = Vector3.Lerp(leftDoor.position, leftOld, doorSpeed * Time.deltaTime);
            rightDoor.position = Vector3.Lerp(rightDoor.position, rightOld, doorSpeed * Time.deltaTime);
        }
        
    }
}
