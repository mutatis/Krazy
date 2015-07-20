using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DestructibleBlock : MonoBehaviour {
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
        while (Time.time - timeAtExplosion < timeLimit)
        {
            foreach (var shard in shards)
            {
                var velocity = (shard.position - transform.position).normalized * fragmentSpeed;
                Quaternion.Lerp(shard.rotation, rotationDir, Time.deltaTime * rotation);
                shard.Translate(velocity * Time.deltaTime);
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
