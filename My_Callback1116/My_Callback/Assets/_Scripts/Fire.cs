﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
    public List<ParticleHelper> particles;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        foreach  (ParticleHelper ph in particles)
        {
            if (ph.varyAlpha)
            {
                ph.IncreaseAlpha();
            }
            if (ph.varyEmission)
            {
                ph.IncreaseEmission();
            }
            if (ph.varyIntensity)
            {
                ph.IncreaseIntensity();
            }
            if (ph.varyRange)
            {
                ph.IncreaseRange();
            }
        }
		
	}
}
