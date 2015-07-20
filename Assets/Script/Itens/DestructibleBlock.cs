using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DestructibleBlock : MonoBehaviour
{
    List<Transform> shards = new List<Transform>();
    public float fragmentSpeed;
    public float rotation;
    public float timeLimit;
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            shards.Add(transform.GetChild(i));
        }
    }

    public IEnumerator Explode()
    {
        var rotationDir = Random.rotation;
        var timeAtExplosion = Time.time;
        List<Vector3> direcoes = new List<Vector3>();

        for (int i = 0; i < shards.Count; i++)
        {
            direcoes.Add(Random.insideUnitCircle);
        }

        while (Time.time - timeAtExplosion < timeLimit)
        {
            for (int i = 0; i < shards.Count; i++)
            {
                var velocity = direcoes[i] * fragmentSpeed;
                Quaternion.Lerp(shards[i].rotation, rotationDir, Time.deltaTime * rotation);
                shards[i].Translate(velocity * Time.deltaTime);
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
