using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour 
{
	public GameObject[] grid;
	public GameObject[] Afrodite;
	public GameObject[] Ares;
	public GameObject[] Zeus;
	public GameObject[] Poseidon;

	public GameObject End;

	public static int minPonto = 40;

	public float tempo = 60;
	
	int x;

	// Use this for initialization
	void Start () 
	{
		Time.timeScale = 1;
		grid = GameObject.FindGameObjectsWithTag("Grid");
		StartCoroutine("GO");
	}
	
	// Update is called once per frame
	void Update () 
	{
		Afrodite = GameObject.FindGameObjectsWithTag("Afrodite");
		Ares = GameObject.FindGameObjectsWithTag("Ares");
		Zeus = GameObject.FindGameObjectsWithTag ("Zeus");
		Poseidon = GameObject.FindGameObjectsWithTag ("Poseidon");

		x = Afrodite.Length + Ares.Length + Zeus.Length + Poseidon.Length;

		if(x >= grid.Length)
		{
			End.SetActive(true);
		}
	}

	IEnumerator GO()
	{
		yield return new WaitForSeconds (tempo);
		Time.timeScale = 0;
		End.SetActive(true);
	}
}
