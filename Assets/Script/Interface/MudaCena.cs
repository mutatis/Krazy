using UnityEngine;
using System.Collections;

public class MudaCena : MonoBehaviour 
{

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void LoadScene(string level)
	{
		PlayerPrefs.SetString ("Loading", level);
		Application.LoadLevel ("Loading");
	}
}
