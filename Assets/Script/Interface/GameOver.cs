using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameOver : MonoBehaviour {
    public List<GameObject> estrelas;

    int score;
    int qtdEstrelas;
    SceneMaster sceneMaster;

    void Start()
    {
        sceneMaster = GameObject.FindGameObjectWithTag("SceneMaster").GetComponent<SceneMaster>();
        qtdEstrelas = sceneMaster.GetStarCount();
        StartCoroutine(MostrarEstrelas());
    }

    IEnumerator MostrarEstrelas()
    {
        for (int i = 0; i < qtdEstrelas; i++)
        {
            yield return new WaitForSeconds(1);
            estrelas[i].SetActive(true);
        }
    }


}
