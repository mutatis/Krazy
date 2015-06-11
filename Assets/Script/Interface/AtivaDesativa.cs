using UnityEngine;
using System.Collections;

public class AtivaDesativa : MonoBehaviour
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void AD(GameObject obj)
	{
		if(obj.active)
		{
			obj.SetActive(false);
		}
		else
		{
			obj.SetActive(true);
		}
	}
}
