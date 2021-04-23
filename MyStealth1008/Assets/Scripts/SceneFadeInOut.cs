using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFadeInOut : MonoBehaviour
{
    public float fadeSpeed = 1.5f;
    private bool sceneStarting = true;
    private RawImage rawImage = null;
    public bool IsGameOver;
    private  Text textUp, textDown,textCen;
    void Awake()
    {
        rawImage = GetComponent<RawImage>();
        textUp = GameObject.FindWithTag(Tags.tip2).GetComponent<Text>();
        textDown = GameObject.FindWithTag(Tags.tip1).GetComponent<Text>();
        textCen = GameObject.FindWithTag(Tags.TextCen).GetComponent<Text>();

        textCen.enabled = false;
        textUp.enabled = false;
        textDown.enabled = false;

        textCen.color = Color.clear;
        textUp.color = Color.clear;
        textDown.color = Color.clear;

        IsGameOver = false;
    }
    void Start ()
    {
		
	}
	
	void Update ()
    {
       
	}
    void FixedUpdate()
    {
        if (sceneStarting)
        {
            StartScene();
        }
        if (IsGameOver)
        {
            EndScene();
        }
    }
    void FadeToClear()
    {

        rawImage.color = Color.Lerp(rawImage.color, Color.clear, fadeSpeed * Time.deltaTime);


    }
    void FadeToBlack()
    {
        rawImage.color = Color.Lerp(rawImage.color, Color.black, fadeSpeed * Time.deltaTime);
    }
    void StartScene()
    {
        FadeToClear();
        StartText();

        if (rawImage.color.a<0.05f)
        {
            rawImage.color = Color.clear;
            rawImage.enabled = false;
            sceneStarting = false;
            

 
 
        }

    }
    void StartText()
    {
        textDown.enabled = true;
        textDown.text = "人物控制" + "    WASD\n" + "潜行" + "           左Shift\n" + "吸引注意" + "    X\n" + "使用" + "           Z";
        textUp.enabled = true;
        textUp.text = "任务目标：拿到钥匙，乘坐电梯离开";
        textDown.color = Color.Lerp(textDown.color, Color.white, fadeSpeed * Time.deltaTime);
        textUp.color = Color.Lerp(textUp.color, Color.white, fadeSpeed * Time.deltaTime);

        if (textCen)
        {
            textCen.color = Color.Lerp(textCen.color, Color.clear, 3 * fadeSpeed * Time.deltaTime);
            if (textCen.color.a < 0.1f)
            {
                textCen.enabled = false;
            }

        }
    }
    void EndText()
    {
        textDown.color = Color.Lerp(textDown.color, Color.clear, 2*fadeSpeed * Time.deltaTime);
        textUp.color = Color.Lerp(textUp.color, Color.clear, 2*fadeSpeed * Time.deltaTime);
        textCen.enabled = true;

        if (IsGameOver)
        {
            
            textCen.text = "任务失败...Try again~~";
              
        }
        else
        {
            textCen.text = "任务完成！";
        }
        textCen.color = Color.Lerp(textCen.color, Color.white, 2*fadeSpeed * Time.deltaTime);


    }
    public void EndScene()
    {
        rawImage.enabled = true;
        EndText();
        FadeToBlack();

        if (rawImage.color.a>0.95f)
        {
            rawImage.color = Color.black;
            SceneManager.LoadScene("Main");
        }
    }
}
