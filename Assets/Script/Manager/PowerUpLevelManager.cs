using UnityEngine;
using System.Collections;

public class PowerUpLevelManager : MonoBehaviour 
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void Resume(GameObject obj)
	{
		Time.timeScale = 1;
		obj.SetActive (false);
	}
}
