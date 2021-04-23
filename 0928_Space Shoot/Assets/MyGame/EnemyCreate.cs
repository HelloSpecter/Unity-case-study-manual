using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyCreate : MonoBehaviour
{
    public  float dtTime = 1.0f;
    public Text ScoreText, GameOverText, RestartText;
    public GameObject enemy_prefab;
    [HideInInspector]
    float nextEnemy = 0.0f;
    int score = 0;
    bool gameOver;
    bool Restart;
    //int temp3;
    // Start is called before the first frame update
    public void GameOver()
    {
        gameOver = true;
        GameOverText.text = "游 戏 结 束 ！";
        RestartText.text = "按【R】键重新开始！";
        Restart = true;
        //temp3 = 0;
    }
    void Start()
    {
        GameOverText.text ="";
        RestartText.text = "";
        gameOver = false;
        Restart = false;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if ((Time.time> nextEnemy)&&!gameOver)
        {
            nextEnemy = Time.time + dtTime;
            if (Random.Range(-1,1)<0)
            {
                GameObject enemyNew = Instantiate(enemy_prefab, new Vector3(-2.80f, 3.0f, Random.Range(-1.75f, 2.52f)), Quaternion.Euler(90, 0, 0));
            }
            else
            {
                GameObject enemyNew = Instantiate(enemy_prefab, new Vector3(2.49f, 3.0f, Random.Range(-1.75f, 2.52f)), Quaternion.Euler(90, 0, 0));

            }

            //enemyNew.transform.Translate(new Vector3(1, 0, Random.Range(-1, 1))*Time.deltaTime* enemy_speed);

        }
        if (Restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
        //if (Restart)
        //{
        //    RestartText.text = "按【R】键重新开始！";
            //temp3++;
            //if (temp3%50==0)
            //{
            //    RestartText.text = "";
            //    temp3 = 0;
            //}
            //else
            //{
            //    RestartText.text = "按【R】键重新开始！";

            //}
            //if (temp3%50==0)
            //{
            //    RestartText.text = "2";
            //}
            //if (temp3 % 100==0)
            //{
            //    RestartText.text = "1";
            //    //RestartText.text = "按【R】键重新开始！";
            //    temp3 = 0;
            //}
            //else
            //{
            //    RestartText.text = "2";
            //    temp3++;
            //}

        //}

    }
    public void AddScore()
    {
        UpdateText();
    }
    private void UpdateText()
    {
        score++;
        ScoreText.text = "得分：" + score;
    }
}
