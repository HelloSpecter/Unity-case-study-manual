using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ParticleHelper
{

    
    public ParticleSystem part;
    public Light light;
    public bool varyAlpha;
    public bool varyEmission;
    public bool varyIntensity;
    public bool varyRange;
    public float minAlpha;
    public float maxAlpha;
    public float alphaIncreaseRate;
    public float alphaDecreaseRate;
    public float alphaVariation;
    public float minRate;
    public float maxRate;
    public float rateIncreaseRate;
    public float rateDecreaseRate;
    public float rateVariation;
    public float minIntensity;
    public float maxIntensity;
    public float intensityIncreaseRate;
    public float intensityDecreaseRate;
    public float intensityVariation;
    public float minRange;
    public float maxRange;
    public float rangeIncreaseRate;
    public float rangeDecreaseRate;
    public float rangeVariation;


    public void IncreaseAlpha()
    {
        //ParticleSystem.MainModule partMain = part.GetComponent<ParticleSystem.MainModule>();
        if (part.main.startColor.color.a<maxAlpha)
        {
            ParticleSystem.MainModule main = part.main;
            Color adjustedColour = part.main.startColor.color;
            adjustedColour.a += alphaIncreaseRate * Time.deltaTime;
            adjustedColour.a += Random.Range(0f, alphaVariation);
            main.startColor = adjustedColour;

        }
    }
    public void DecreaseAlpha()
    {
        ParticleSystem.MainModule main = part.main;

        if (part.main.startColor.color.a > minAlpha)
        {
            Color adjustedColour = part.main.startColor.color;
            adjustedColour.a -= alphaDecreaseRate * Time.deltaTime;
            main.startColor = adjustedColour;
        }
    }

    //



    public void IncreaseEmission()
    {
        ParticleSystem.EmissionModule emission = part.emission;

        if (part.emission.rateOverTimeMultiplier < maxRate)
        {
            float adjustedRate = part.emission.rateOverTimeMultiplier;
            adjustedRate += rateIncreaseRate * Time.deltaTime;
            adjustedRate += Random.Range(0f, rateVariation);
            emission.rateOverTimeMultiplier = adjustedRate;
        }
    }
    public void DecreaseEmission()
    {
        ParticleSystem.EmissionModule emission = part.emission;

        if (emission.rateOverTimeMultiplier > minRate)
        {
            float adjustedRate = emission.rateOverTimeMultiplier;
            adjustedRate -= rateDecreaseRate * Time.deltaTime;
            emission.rateOverTimeMultiplier = adjustedRate;
        }
    }

    ////



    public void IncreaseIntensity()
    {

        if (light.intensity< maxIntensity)
        {
            light.intensity += intensityIncreaseRate * Time.deltaTime;
            light.intensity += Random.Range(0f, intensityVariation);
        }
    }
    public void DecreaseIntensity()
    {
        if (light.intensity > minIntensity)
        {
            light.intensity -= intensityDecreaseRate * Time.deltaTime;
        }
    }
    //灯光范围变化函数
    

    public void IncreaseRange()
    {
        
        if (light.range < maxRange)
        {
            light.range += rangeIncreaseRate * Time.deltaTime;
            light.range += Random.Range(0f, rangeVariation);
        }
    }
    public void DecreaseRange()
    {
        if (light.range > minRange)
        {
            light.range -= rangeDecreaseRate * Time.deltaTime;
        }
    }

}
