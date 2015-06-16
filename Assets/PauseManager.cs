using UnityEngine;
using System.Collections;

public class PauseManager : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*if(gameObject.active)
		{
			Time.timeScale = 0;
		}*/
	}

	public void Resume()
	{
		Time.timeScale = 1;
		gameObject.SetActive (false);
	}

	public void Menu(string level)
	{
		PlayerPrefs.SetString ("Loading", level);
		Application.LoadLevel ("Loading");
	}
}
