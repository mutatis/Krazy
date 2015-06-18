using UnityEngine;
using System.Collections;

public class SceneMaster : MonoBehaviour {
    public int metaPontuacao;
    public int tempoLimiteFase;
    public GameObject telaGameOver;

	GameObject[] grid;
	GameObject[] Afrodite;
	GameObject[] Ares;
	GameObject[] Zeus;
	GameObject[] Poseidon;
	
	public GameObject End;
	
	public float tempo = 60;
	
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

        x = Afrodite.Length + Ares.Length + Zeus.Length + Poseidon.Length;

        if (x >= grid.Length)
        {
            End.SetActive(true);
        }
    }


	IEnumerator GO()
	{
		yield return new WaitForSeconds (tempo);
		GameOver();
	}

    void GameOver()
    {
        Time.timeScale = 0;
        GameObject.Instantiate(telaGameOver);
    }
}