using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lista : MonoBehaviour
{

	public ArrayList obj = new ArrayList();
	public ArrayList obj2 = new ArrayList();
	public int x;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		print (obj.Count + " " + obj2.Count);
		if(x == 4)
		{
			if(obj.Count > obj2.Count && obj.Count > 3)
			{
				for(int i = 0; i < obj.Count; i++)
				{
					Destroy ((GameObject)obj[i]);
				}
			}
			else if(obj.Count < obj2.Count && obj2.Count > 3)
			{
				for(int i = 0; i < obj2.Count; i++)
				{
					Destroy ((GameObject)obj2[i]);
				}
			}
			else
			{
				Destroy(gameObject);
			}
		}
	}
}