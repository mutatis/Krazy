﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lista : MonoBehaviour
{

	public ArrayList obj = new ArrayList();
	public ArrayList obj2 = new ArrayList();
	public int x;

	GameObject objeto;

	Animator anim;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine("GO");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(x == 4)
		{
			if(obj.Count > 3)
			{
				for(int i = 0; i < obj.Count; i++)
				{
					objeto = (GameObject)obj[i];
					anim = objeto.GetComponent<Animator>();
					anim.SetTrigger("Kill");
					//Destroy ((GameObject)obj[i]);
				}
			}
			else if(obj2.Count > 3)
			{
				for(int i = 0; i < obj2.Count; i++)
				{
					objeto = (GameObject)obj2[i];
					anim = objeto.GetComponent<Animator>();
					anim.SetTrigger("Kill");
					//Destroy ((GameObject)obj2[i]);
				}
			}
			else
			{
				Destroy(gameObject);
			}
		}
	}

	IEnumerator GO()
	{
		yield return new WaitForSeconds(6);
		Destroy(gameObject);
	}
}