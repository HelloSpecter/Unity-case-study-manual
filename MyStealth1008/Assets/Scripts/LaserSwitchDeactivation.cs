using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSwitchDeactivation : MonoBehaviour
{
    public GameObject laser;
    public Material unlockedMat;
    public GameObject player;
    private  Renderer screen;
    void LaserDeactivation()
    {
        laser.SetActive(false);
        
        if (screen.material!=unlockedMat)
        {
            screen.material = unlockedMat;
            GetComponent<AudioSource>().Play();
        }
        

    }
	void Start ()
    {

       screen = transform.Find("prop_switchUnit_screen").GetComponent<Renderer>();
        //unlockedMat.name = "prop_switchUnit_screen_unlocked_mat";
    }
	

	void Update ()
    {
		
	}
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject==player)
        {
            if (Input.GetButton("Switch")&& screen.materials[0] != unlockedMat)
            {
                LaserDeactivation();
            }
        }
    }
}
