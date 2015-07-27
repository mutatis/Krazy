using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameOver : MonoBehaviour 
{
    public List<GameObject> estrelas;
	public GameObject nextLevelButton;
	public AudioSource audio;

    int score;
    int qtdEstrelas;
    SceneMaster sceneMaster;

    void Start()
    {
        sceneMaster = GameObject.FindGameObjectWithTag("SceneMaster").GetComponent<SceneMaster>();
        qtdEstrelas = sceneMaster.GetStarCount();
		if(qtdEstrelas > PlayerPrefs.GetInt(PlayerPrefs.GetString("Loading")))
		{
			PlayerPrefs.SetInt(PlayerPrefs.GetString("Loading"), qtdEstrelas);
		}
		if(qtdEstrelas > 0)
		{
			audio.Play();
		}
		//CreatedObj obj = GameObject.FindGameObjectWithTag ("Created").GetComponent<CreatedObj> ();
        //obj.StopWave();
        StartCoroutine(MostrarEstrelas());
        sceneMaster.enabled = false;
    }

    IEnumerator MostrarEstrelas()
    {
        for (int i = 0; i < qtdEstrelas; i++)
        {
            yield return new WaitForSeconds(1);
            estrelas[i].SetActive(true);
        }

		if(qtdEstrelas > 0) 
			nextLevelButton.SetActive (true);
    }


}

public enum GameOverType
{
    Timeout,
    FullBoard
}
