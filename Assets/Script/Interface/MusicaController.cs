using UnityEngine;
using System.Collections;

public class MusicaController : MonoBehaviour 
{

	public AudioSource audio;

	void Awake()
	{
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(PlayerPrefs.GetInt("Musica") == 0 && !audio.isPlaying)
		{
			audio.Play();
		}
		else if(PlayerPrefs.GetInt("Musica") == 1)
		{
			audio.Stop();
		}
	}
}
