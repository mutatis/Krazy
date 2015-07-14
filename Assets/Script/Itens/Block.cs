using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
    public AudioClip spawnSound;
    SceneMaster sceneMaster;
    public int valorPontos = 1;

    void Start()
    {
        sceneMaster = GameObject.FindGameObjectWithTag("SceneMaster").GetComponent<SceneMaster>();
    }

    public void OnKill()
    {
        sceneMaster.AumentarPontuacao(valorPontos);
        if (sceneMaster.reviveRefCount > 0) sceneMaster.reviveRefCount--;
        Destroy(gameObject);
    }

    public void SetTarget(GameObject target, bool useNoise = false)
    {
        var cpm = GetComponent<BlockMovement>();
        cpm.StartCoroutine(cpm.GoToTarget(target.transform, useNoise));
        //target.GetComponent<BlockSquare>().ok = false;
    }

}
