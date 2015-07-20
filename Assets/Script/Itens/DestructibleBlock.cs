using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DestructibleBlock : MonoBehaviour
{
    List<Transform> shards = new List<Transform>();

    public float range;
    public float rotation;
    public float timeLimit;

	public SpriteRenderer padrao;

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            shards.Add(transform.GetChild(i));
        }
    }

	public void Explodir()
	{
		StartCoroutine("Explode");
		padrao.enabled = false;
	}

    public IEnumerator Explode()
    {
        var rotationDir = Random.rotation;
        var timeAtExplosion = Time.time;
        List<Vector3> direcoes = new List<Vector3>();
        var velocities = new List<Vector3>();

        for (int i = 0; i < shards.Count; i++)
        {
            direcoes.Add(Random.insideUnitCircle);
            velocities.Add(Vector3.zero);
        }

        while (Time.time - timeAtExplosion < timeLimit)
        {
            for (int i = 0; i < shards.Count; i++)
            {
                var target = direcoes[i] * range;
                var velocity = velocities[i];
                Quaternion.Lerp(shards[i].rotation, rotationDir, Time.deltaTime * rotation);
                Vector3.SmoothDamp(shards[i].position, target, ref velocity, timeLimit);
                velocities[i] = velocity;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
