using UnityEngine;
using System.Collections;

public class musicaController : MonoBehaviour 
{

	public AudioSource audio;

	void Awake()
	{
		DontDestroyOnLoad (gameObject);
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(PlayerPrefs.GetInt("Musica") == 0)
		{
			audio.Play();
		}
		else
		{
			audio.Stop();
		}
	}
}
