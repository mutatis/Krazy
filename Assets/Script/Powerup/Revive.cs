using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Revive : MonoBehaviour 
{
	public List<GameObject> obj;

	public AudioClip audio;

	public GameObject endGame;
	public GameObject panelEnd;
    public GameMaster gameMaster;
    public int extraTime;
    public GameOverType reviveMode;
    private SceneMaster sceneMaster;
	Animator anim;

	GameObject[] Afrodite;
	GameObject[] Ares;
	GameObject[] Zeus;
	GameObject[] Poseidon;
	GameObject[] Esqueleto;
	GameObject[] Pena;

    void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameMaster>();
    }

    public void Continue()
    {
        AudioSource.PlayClipAtPoint(audio, transform.position);
        sceneMaster = GameObject.FindGameObjectWithTag("SceneMaster").GetComponent<SceneMaster>();

        if (reviveMode == GameOverType.FullBoard)
        {
            if (gameMaster && gameMaster.GetPowerUpCount(PowerUps.Revive) > 0)
            {
                gameMaster.ConsumePowerUp(PowerUps.Revive);
                ContinueLevel();
            }
            else
            {
                print("You don't have a revive powerUp.");
                return;
            }
                
        }

        if(reviveMode == GameOverType.Timeout)
        {
            if (gameMaster && gameMaster.GetPowerUpCount(PowerUps.ExtraTime) > 0)
            {
                gameMaster.ConsumePowerUp(PowerUps.ExtraTime);
                ExtraTime();
            }
            else
            {
                print("You don't have an extra time powerUp.");
                return;
            }
                
        }

        sceneMaster.enabled = true;
        sceneMaster.BeginLevel(true);

        CreatedObj creat = GameObject.FindGameObjectWithTag("Created").GetComponent<CreatedObj>();
        creat.StartCoroutine("LaunchWave");

        sceneMaster.StartCoroutine("GO");
        sceneMaster.timer.StartTimer();
        Destroy(endGame);
    }

    public void SetReviveMode(GameOverType mode)
    {
        reviveMode = mode;
    }

    void ContinueLevel()
    {
        Afrodite = GameObject.FindGameObjectsWithTag("Afrodite");
        Ares = GameObject.FindGameObjectsWithTag("Ares");
        Zeus = GameObject.FindGameObjectsWithTag("Zeus");
        Poseidon = GameObject.FindGameObjectsWithTag("Poseidon");
        Esqueleto = GameObject.FindGameObjectsWithTag("Esqueleto");
        Pena = GameObject.FindGameObjectsWithTag("Pena");

        for (int i = 0; i < Afrodite.Length; i++)
        {
            obj.Add(Afrodite[i]);
        }
        for (int i = 0; i < Ares.Length; i++)
        {
            obj.Add(Ares[i]);
        }
        for (int i = 0; i < Zeus.Length; i++)
        {
            obj.Add(Zeus[i]);
        }
        for (int i = 0; i < Poseidon.Length; i++)
        {
            obj.Add(Poseidon[i]);
        }
        for (int i = 0; i < Esqueleto.Length; i++)
        {
            obj.Add(Esqueleto[i]);
        }
        for (int i = 0; i < Pena.Length; i++)
        {
            obj.Add(Pena[i]);
        }

        int x = obj.Count;

        float temp = x * 0.15f;

        for (int i = 0; i < (int)temp; i++)
        {
            int randomTemp = Random.Range(0, x);
            anim = obj[randomTemp].gameObject.GetComponentInChildren<Animator>();
            anim.SetTrigger("Revive");            
            x--;
            obj.Remove(obj[randomTemp]);
        }
    }

    void ExtraTime()
    {
        sceneMaster.tempoLimiteFase = extraTime;
        sceneMaster.timer.SetTimer(extraTime);
    }
}
