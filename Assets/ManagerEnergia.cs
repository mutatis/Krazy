using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ManagerEnergia : MonoBehaviour 
{

	public Text text;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		text.text = "Energia: " + PlayerPrefs.GetInt("Energia").ToString();
	}
}
