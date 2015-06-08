using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour 
{
	public GameObject[] grid;
	public GameObject[] Afrodite;
	public GameObject[] Ares;
	public GameObject[] Zeus;
	public GameObject[] Poseidon;
	int x;

	// Use this for initialization
	void Start () 
	{
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
			Application.LoadLevel("GameOver");
		}
	}

	IEnumerator GO()
	{
		yield return new WaitForSeconds (60);
		Application.LoadLevel("GameOver");
	}
}
