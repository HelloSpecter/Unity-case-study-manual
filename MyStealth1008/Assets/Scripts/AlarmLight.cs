using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmLight : MonoBehaviour
{
    public float fadeSpeed = 2f;
    public float highIntensity = 4f;
    public float lowIntensity = 0.5f;
    public float changeMargin = 0.2f;
    public bool alarmOn;
    private float targetIntensity;
    private Light alarmLight;

    void Awake()
    {
        alarmLight = GetComponent<Light>();
        alarmLight.intensity = 0f;
        targetIntensity = highIntensity;
    }
    void Start ()
    {
		
	}
	
	void Update ()
    {
        if (alarmOn)
        {
            alarmLight.intensity = Mathf.Lerp(alarmLight.intensity, targetIntensity, Time.deltaTime * fadeSpeed);
            CheckTargetIntensity();
        }
        else
        {
            alarmLight.intensity = Mathf.Lerp(alarmLight.intensity, 0f, Time.deltaTime * fadeSpeed);

        }
    }
    void CheckTargetIntensity()
    {
        if (Mathf.Abs(targetIntensity-alarmLight.intensity)<changeMargin)
        {
            if (targetIntensity==highIntensity)
            {
                targetIntensity = lowIntensity;
            }
            else
            {
                targetIntensity = highIntensity;
            }
        }
    }
}
