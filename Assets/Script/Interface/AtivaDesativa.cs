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
			Time.timeScale = 1;
		}
		else
		{
			obj.SetActive(true);
			Time.timeScale = 0;
		}
	}
}
