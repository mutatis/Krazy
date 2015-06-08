using UnityEngine;
using System.Collections;

public class MudaCena : MonoBehaviour 
{

	// Use this for initialization
	void Start ()
	{
		if(Time.timeScale != 0)
		{
			Application.LoadLevel("Game");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void LoadScene(string level)
	{
		Application.LoadLevel (level);
	}
}
