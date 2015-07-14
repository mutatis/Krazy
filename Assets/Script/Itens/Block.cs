using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
    public AudioClip spawnSound;
    SceneMaster sceneMaster;
    public int valorPontos = 1;
    public int quantidadeCombo;
    public bool ancora;
    public GameObject selectionOverlay;
    public GameObject tiro;

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

    public void OnSelectBlock()
    {
        selectionOverlay.SetActive(true);
        //print(name + " is now selected");
    }

    public void OnDeselectBlock()
    {
        selectionOverlay.SetActive(false);
        print(name + " was deselected");
    }

    public void OnMouseDown()
    {
        print("down " + Time.time);
        if(!ancora)
            sceneMaster.gameObject.SendMessage("OnClickBlock", gameObject);
    }

    public void ChecarCombo()
    {
        GameObject tempObj = Instantiate(tiro, transform.position, transform.rotation) as GameObject;
        tempObj.GetComponent<Lista>().quant = quantidadeCombo;
    }
}
