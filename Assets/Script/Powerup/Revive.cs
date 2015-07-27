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
        if (gameMaster && gameMaster.GetPowerUpCount(PowerUps.Revive) > 0)
        {
            StartCoroutine("ContinueCoroutine");
            gameMaster.ConsumePowerUp(PowerUps.Revive);
        }
        else
            print("You don't have a revive power up.");
        
    }

	public IEnumerator ContinueCoroutine()
	{
		panelEnd.SetActive (false);

		AudioSource.PlayClipAtPoint (audio, transform.position);

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
            sceneMaster.reviveRefCount++;
            anim.SetTrigger("Revive");
			print(sceneMaster.reviveRefCount);
			x --;
			obj.Remove(obj[randomTemp]);
		}

        while (sceneMaster.reviveRefCount > 0)
        {
            //print(Time.time);
            yield return new WaitForEndOfFrame();
        }
		sceneMaster.enabled = true;
		sceneMaster.BeginLevel (true);

		CreatedObj creat = GameObject.FindGameObjectWithTag ("Created").GetComponent<CreatedObj> ();
		creat.StartCoroutine ("LaunchWave");

		sceneMaster.StartCoroutine("GO");
        sceneMaster.timer.StartTimer();
		Destroy (endGame);
	}
}
