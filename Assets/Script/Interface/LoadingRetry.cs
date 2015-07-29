using UnityEngine;
using System.Collections;

public class LoadingRetry : MonoBehaviour 
{
    //public int idCenaLoading;

	public void Retry()
	{
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameMaster>().OnChangeLevel(Application.loadedLevel);
	}
}
