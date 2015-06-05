﻿using UnityEngine;
using System.Collections;

public class SelectPOsition : MonoBehaviour 
{

	private Vector3 direction2;

	public MovMouse mouse;

	public AudioClip spawn;

	private Vector3 velocity = Vector3.zero;
    GameObject target;
    public float noiseRange;

	bool pare;

	// Use this for initialization
	void Start ()
	{
		AudioSource.PlayClipAtPoint(spawn, transform.position, 1);
	}
	
	// Update is called once per frame
	void Update ()
	{
		/*if(!pare)
		{
			mouse.quadradoSelecionado = target;
			dist = Vector3.Distance(target.transform.position, transform.position);
			if(dist > 0.1f)
			{
                mouse.playingAnimation = true;
				direction2 = (target.transform.position - transform.position);
                Vector3 destination = transform.position + direction2;
				transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, 0.25f);
			}
			else
			{
				
				mouse.enabled = true;
				mouse.pode = true;
                mouse.quadradoSelecionado = target;
                mouse.playingAnimation = false;
				pare = true;
			}
		}*/
	}

    IEnumerator GoToTarget()
    {
        var rnd = new System.Random();
        mouse.quadradoSelecionado = target;
        var dist = Vector3.Distance(target.transform.position, transform.position);
        var direction2 = (target.transform.position - transform.position);
        var noiseDirection = new Vector3(-direction2.y, direction2.x, 0).normalized;
        var magnitudeInicial = direction2.magnitude;
        while(dist > .1f) 
        {
            direction2 = (target.transform.position - transform.position);
            var noise = (rnd.NextDouble() + Mathf.Sin(Time.time * 15)) * noiseRange;
            mouse.playingAnimation = true;
            
            Vector3 destination = transform.position + direction2;
            transform.position = Vector3.SmoothDamp(transform.position, destination + (noiseDirection * (float)noise * (direction2.magnitude / magnitudeInicial)), ref velocity, 0.25f);
            yield return new WaitForEndOfFrame();
        }
        print("terminou");
        mouse.enabled = true;
        mouse.pode = true;
        mouse.quadradoSelecionado = target;
        mouse.playingAnimation = false;
    } 

    public void SetTarget(GameObject target)
    {
        this.target = target;
        target.GetComponent<BlockSquare>().ok = false;
    }
}
