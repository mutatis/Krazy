using UnityEngine;
using System.Collections;

public class VerificaEstrelas : MonoBehaviour 
{
	public string nomeFase;
	public GameObject[] estrelas;
	int temp;

	// Use this for initialization
	void Start () 
	{
		temp = PlayerPrefs.GetInt (nomeFase);

		for(int i = 0; i < temp; i++)
		{
			estrelas[i].SetActive(true);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}