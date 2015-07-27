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
    public Timer timer;
    public ScoreMeter[] scoreMeters;

    public int score;
    GameMaster gameMaster;

	GameObject[] grid;
	GameObject[] Afrodite;
	GameObject[] Ares;
	GameObject[] Zeus;
	GameObject[] Poseidon;
	GameObject[] Esqueleto;
	GameObject[] Pena;

    public int reviveRefCount = 0;

	//public GameObject End;
	
	//public float tempo = 60;
	
	int x;

	// Use this for initialization
	void Start () 
	{
		Time.timeScale = 0;
		grid = GameObject.FindGameObjectsWithTag("Grid");
		StartCoroutine("GO");
        gameMaster = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameMaster>();
        gameMaster.faseAtual = Application.loadedLevel.ToString();
        if (scoreMeters.Length == 3) 
		{
			scoreMeters[0].SetGoal(meta1Estrela);
			scoreMeters[0].SetFloor(0);
			scoreMeters[1].SetGoal(meta2Estrelas);
			scoreMeters[1].SetFloor(meta1Estrela);
			scoreMeters[2].SetGoal(meta3Estrelas);
			scoreMeters[2].SetFloor(meta2Estrelas);
		}
            
    }

    public void BeginLevel(bool restart = false)
    {
        Time.timeScale = 1;
		if(!restart)
        	timer.SetTimer(tempoLimiteFase);
        timer.StartTimer();
		gameObject.GetComponent<MouseInteraction> ().isPaused = false;
    }
	
	// Update is called once per frame
	void Update () 
    {
        ChecarGrid();
        if (scoreMeters.Length == 3) 
		{
			foreach(var smeter in scoreMeters) 
			{
				smeter.SetScore(score);
			}
		}
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
            GameOver(GameOverType.FullBoard);
        }
    }


    public int Score { get { return score; }  }

	IEnumerator GO()
	{
        var timer = .0f;
        while(timer < tempoLimiteFase)
        {
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;
        }
		GameOver(GameOverType.Timeout);
	}

    public void AumentarPontuacao(int qtd)
    {
        score += qtd;
    }

    void GameOver(GameOverType mode)
    {
        //Time.timeScale = 0;
        GameObject.Instantiate(telaGameOver);
        telaGameOver.GetComponent<Revive>().SetReviveMode(mode);
        timer.StopTimer();
		var spawner = GameObject.FindGameObjectWithTag ("Created").GetComponent<CreatedObj> ();
		spawner.StopWave ();
		gameObject.GetComponent<MouseInteraction> ().isPaused = true;
        print("oooohhh");
        //this.enabled = false;
    }

    public int GetStarCount()
    {
        var count = 0;
        if (score >= meta3Estrelas)
            count = 3;
        else if (score >= meta2Estrelas)
            count = 2;
        else if (score >= meta1Estrela)
            count = 1;

        if (gameMaster.GetStarsForLevel(Application.loadedLevel) < count)
        {
            gameMaster.SetStarsForLevel(count);
        }

        return count;
    }
}