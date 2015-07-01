using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour 
{

	void Awake() 
	{
		if (Advertisement.isSupported)
		{
			Advertisement.Initialize ("42224");
		} 
		else 
		{
			Debug.Log("Platform not supported");
		}
	}

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.A))
		{
			Advertisement.Show ();
		}
	}
}
