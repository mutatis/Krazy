using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using SIS;

public class ManagerOuro : MonoBehaviour
{

	public Text text;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		text.text = "Ouro: " + 99999;
	}
}