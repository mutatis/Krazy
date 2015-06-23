using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SceneMaster : MonoBehaviour 
{
	public List<GameObject> obj;

    public int meta1Estrela;
    public int meta2Estrelas;
    public int meta3Estrelas;
    public int tempoLimiteFase;

    public GameObject telaGameOver = null;

    private int score;


	GameObject[] grid;
	GameObject[] Afrodite;
	GameObject[] Ares;
	GameObject[] Zeus;
	GameObject[] Poseidon;
	GameObject[] Esqueleto;
	GameObject[] Pena;
	
	//public GameObject End;
	
	//public float tempo = 60;
	
	int x;

	// Use this for initialization
	void Start () 
	{
		Time.timeScale = 0;
		grid = GameObject.FindGameObjectsWithTag("Grid");
		StartCoroutine("GO");
    }
	
	// Update is called once per frame
	void Update () 
    {
        ChecarGrid();
	}

    private void ChecarGrid()
    {
        Afrodite = GameObject.FindGameObjectsWithTag("Afrodite");
        Ares = GameObject.FindGameObjectsWithTag("Ares");
        Zeus = GameObject.FindGameObjectsWithTag("Zeus");
        Poseidon = GameObject.FindGameObjectsWithTag("Poseidon");
		Esqueleto = GameObject.FindGameObjectsWithTag("Esqueleto");
		Pena = GameObject.FindGameObjectsWithTag("Pena");

		x = Afrodite.Length + Ares.Length + Zeus.Length + Poseidon.Length + Esqueleto.Length + Pena.Length;

        if (x >= grid.Length)
        {
            GameOver();
        }
    }


    public int Score { get { return score; }  }

	IEnumerator GO()
	{
		yield return new WaitForSeconds (tempoLimiteFase);
		GameOver();
	}

    public void AumentarPontuacao(int qtd)
    {
        score += qtd;
    }

    void GameOver()
    {
        //Time.timeScale = 0;
        GameObject.Instantiate(telaGameOver);
        this.enabled = false;
    }

    public int GetStarCount()
    {
        if (score >= meta3Estrelas)
            return 3;
        if (score >= meta2Estrelas)
            return 2;
        if (score >= meta1Estrela)
            return 1;
        return 0;
    }
}