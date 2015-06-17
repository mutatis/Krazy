using UnityEngine;
using System.Collections;

public class MusicaController : MonoBehaviour 
{

	AudioSource audio;

	void Awake()
	{
		DontDestroyOnLoad (gameObject);
	}

	void Start()
	{
		audio = gameObject.GetComponent<AudioSource> ();
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
