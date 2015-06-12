using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
    public AudioClip spawnSound;
    void Start()
    {

    }
    void Update()
    {

    }

    public void SetTarget(GameObject target, bool useNoise = false)
    {
        var cpm = GetComponent<BlockMovement>();
        cpm.StartCoroutine(cpm.GoToTarget(target.transform, useNoise));
        //target.GetComponent<BlockSquare>().ok = false;
    }

}
