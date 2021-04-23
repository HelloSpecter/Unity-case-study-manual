using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Original : MonoBehaviour
{
    public float enemy_speed = 2.0f;
    public GameObject EnemyBullet_prefab;
    public GameObject EnemyExplosion;
    public float rateFire = 0.4f;
    public float nextFire = 0.3f;
    float beginDirection;
    string begin = null;
    bool IsDead = false;
    Renderer EnemyRenderer;
    [HideInInspector]
    public EnemyCreate enemyCreate;
    

    // Start is called before the first frame update
    void Start()
    {
        EnemyRenderer = GetComponent<Renderer>();
        beginDirection = Random.Range(-1.0f, 1.0f);
        if (transform.localPosition.x<0)
        {
            begin = "L";

        }
        else if(transform.localPosition.x > 0)
        {
            begin = "R";
        }
        GameObject m_gameObject = GameObject.FindWithTag("GameController");
        enemyCreate = m_gameObject.GetComponent<EnemyCreate>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        switch (begin)
        {
            case "L":
                transform.Translate(new Vector3(1, 0, beginDirection) * Time.deltaTime * enemy_speed, Space.World);
                break;
            case "R":
                transform.Translate(new Vector3(-1, 0, beginDirection) * Time.deltaTime * enemy_speed, Space.World);
                break;
            default:
                break;
        }
        if ((Time.time> nextFire)&& EnemyRenderer.enabled)
        {
            nextFire = Time.time + rateFire;
            Vector3 localpos = transform.localPosition;
            localpos.z -= 0.7f;
            GameObject nnemybullet = Instantiate(EnemyBullet_prefab, localpos, transform.rotation);
        }
        if (IsDead)
        {
            IsDead = false;
            EnemyRenderer.enabled = false;
            GameObject Explosion = Instantiate(EnemyExplosion, transform.localPosition, transform.rotation);
            enemyCreate.AddScore();


        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Prefab_bullet_player"&& EnemyRenderer.enabled)
        {
            Destroy(other.gameObject);
            IsDead = true;
        }
    }
}
