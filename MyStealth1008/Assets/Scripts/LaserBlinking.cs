using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBlinking : MonoBehaviour 
{
	public float onTime=1.5f;
	public float offTime=1.55f;
	public float HeardDis = 5.0f;//能听到声音的最大距离
	private float timer;
	private Renderer laserRenderer;
	private Light laserLight;

	private GameObject player;
	private float Distance;
	AudioSource LaserAudio;
	void Awake()
    {
		laserRenderer = GetComponent<Renderer>();
		laserLight = GetComponent<Light>();
		timer = 0f;
		LaserAudio = GetComponent<AudioSource>();
		LaserAudio.volume = 0f;
    }
	void SwitchBeam()
    {
		timer = 0f;
		laserRenderer.enabled = !laserRenderer.enabled;
		laserLight.enabled = !laserLight.enabled;
		LaserAudio.enabled = !LaserAudio.enabled;

	}
	void Start () 
	{
		
	}
	
	void Update () 
	{
		timer += Time.deltaTime;
        if (laserRenderer.enabled&&timer>onTime)
		{
			SwitchBeam();
        }
		if (!laserRenderer.enabled && timer > offTime)
		{
			SwitchBeam();
		}
		//Control the music when player is closing
		player = GameObject.FindWithTag(Tags.Player);
		Distance = (transform.position - player.transform.position).magnitude;
        if (Distance<= HeardDis && LaserAudio.enabled)
        {
			LaserAudio.volume = 1.0f - Distance / HeardDis;//距离换算百分比，距离越近声音越大
        }
	}
    void OnTriggerEnter(Collider other)
    {

    }
}
