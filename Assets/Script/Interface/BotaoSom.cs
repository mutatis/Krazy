using UnityEngine;
using System.Collections;

public class BotaoSom : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void ADMusica()
	{
		if(PlayerPrefs.GetInt("Musica") == 0)
		{
			PlayerPrefs.SetInt("Musica", 1);
		}
		else
		{
			PlayerPrefs.SetInt("Musica", 0);
		}
	}
}
