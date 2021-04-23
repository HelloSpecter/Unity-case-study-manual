using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player_StateCtro : MonoBehaviour
{
    public static bool StateOfPlayer = true;
    //GameObject Bullet_Newone=null;
    //[SerializeField]
    //public GameObject PrefabOfPlayerBullet;

    //[SerializeField]
    //public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public  void Normal()
    {
        //Vector3 play_position = GameObject.FindWithTag("Player").transform.localPosition;
        //Debug.Log(play_position);
        //GameObject Bullet_Newone = Instantiate(PrefabOfPlayerBullet, play_position, Quaternion.identity);
    }
    public  void ShipDestory()
    {
        //shipboom!
    }
}
