using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Original : MonoBehaviour
{
    public int FireInterval = 50;
    Transform playerExplosion;
    Player_MoveCtro playerCtro;
    public GameObject PrefabOfPlayerBullet;
    int temp1 = 0, temp2 = 0;
    Renderer playerRenderer;
    GameObject playerFlying;
    EnemyCreate enemyCreate;

    //float deadTime;
    // Start is called before the first frame update
    private void Awake()
    {


    }
    void Start()
    {
        Player_StateCtro.StateOfPlayer = true;
        playerExplosion = transform.Find("Smoke_01");
        playerRenderer = GetComponent<Renderer>();
        playerCtro = transform.GetComponent<Player_MoveCtro>();
        playerFlying = transform.Find("Flying").gameObject;
        GameObject m_gameObject = GameObject.FindWithTag("GameController");
        enemyCreate = m_gameObject.GetComponent<EnemyCreate>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {

        if (Player_StateCtro.StateOfPlayer)
        {
            temp1++;
                if (temp1% FireInterval == 0)
                {

                //Player_StateCtro.Normal();
                //Debug.Log(Player_StateCtro.PrefabOfPlayerBullet.name);
                Vector3 player_position = GameObject.FindWithTag("Player").transform.localPosition;
                player_position.z += 0.7f;
                Quaternion player_quaternion = GameObject.FindWithTag("Player").transform.localRotation;
                Debug.Log(player_position);
                GameObject Bullet_Newone = Instantiate(PrefabOfPlayerBullet, player_position,player_quaternion);

            }
           
        }
        if(!Player_StateCtro.StateOfPlayer)
        {
            temp2++;
            playerFlying.SetActive(false);
            playerCtro.enabled = false;
            playerRenderer.enabled = false;
            playerExplosion.gameObject.SetActive(true);
            enemyCreate.GameOver();
            if (temp2%200==0)
            {
                Destroy(gameObject);
            }


        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="BulletOfEnemy"|| other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Player_StateCtro.StateOfPlayer = false;

        }

    }
}
