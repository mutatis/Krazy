using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		Application.LoadLevel(PlayerPrefs.GetString("Loading"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
