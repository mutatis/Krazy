using UnityEngine;
using System.Collections;

public class VerificaEstrelas : MonoBehaviour 
{
	public int idFase;
	public GameObject[] estrelas;
	private GameMaster gameMaster;

	// Use this for initialization
	void Start () 
	{
		gameMaster = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameMaster>();
		int qtdStars = gameMaster.GetStarsForLevel(idFase);

		for(int i = 0; i < qtdStars; i++)
		{
			estrelas[i].SetActive(true);
		}
	}
}