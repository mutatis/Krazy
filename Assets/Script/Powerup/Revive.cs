using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Revive : MonoBehaviour 
{
	public List<GameObject> obj;

	public GameObject endGame;

	Animator anim;

	GameObject[] Afrodite;
	GameObject[] Ares;
	GameObject[] Zeus;
	GameObject[] Poseidon;
	GameObject[] Esqueleto;
	GameObject[] Pena;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Continue()
	{
		SceneMaster sceneMaster = GameObject.FindGameObjectWithTag("SceneMaster").GetComponent<SceneMaster>();

		Afrodite = GameObject.FindGameObjectsWithTag("Afrodite");
		Ares = GameObject.FindGameObjectsWithTag("Ares");
		Zeus = GameObject.FindGameObjectsWithTag("Zeus");
		Poseidon = GameObject.FindGameObjectsWithTag("Poseidon");
		Esqueleto = GameObject.FindGameObjectsWithTag("Esqueleto");
		Pena = GameObject.FindGameObjectsWithTag("Pena");

		for(int i = 0; i < Afrodite.Length; i++)
		{
			obj.Add(Afrodite[i]);
		}
		for(int i = 0; i < Ares.Length; i++)
		{
			obj.Add(Ares[i]);
		}
		for(int i = 0; i < Zeus.Length; i++)
		{
			obj.Add(Zeus[i]);
		}
		for(int i = 0; i < Poseidon.Length; i++)
		{
			obj.Add(Poseidon[i]);
		}
		for(int i = 0; i < Esqueleto.Length; i++)
		{
			obj.Add(Esqueleto[i]);
		}
		for(int i = 0; i < Pena.Length; i++)
		{
			obj.Add(Pena[i]);
		}
		
		int x = obj.Count;
		
		float temp = x * 0.15f;
		
		for(int i = 0; i < (int)temp; i++)
		{
			int randomTemp = Random.Range(0, x);
			anim = obj[randomTemp].gameObject.GetComponentInChildren<Animator>();
			anim.SetTrigger("Kill");
			print("Destruiu");
		}

		sceneMaster.enabled = true;

		CreatedObj creat = GameObject.FindGameObjectWithTag ("Created").GetComponent<CreatedObj> ();
		creat.StartCoroutine ("LaunchWave");

		sceneMaster.StartCoroutine("GO");

		Destroy (endGame);
	}
}
