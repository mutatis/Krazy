using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DestructibleBlock : MonoBehaviour
{
    List<Transform> shards = new List<Transform>();

    public float fragmentSpeed;
    public float deceleration;
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
        var r = Random.insideUnitCircle;
        var rotationDir = Random.Range(-1, 1);
        var timeAtExplosion = Time.time;
        List<Vector3> direcoes = new List<Vector3>();

        for (int i = 0; i < shards.Count; i++)
        {
            direcoes.Add(Random.insideUnitCircle);
        }

        while (Time.time - timeAtExplosion < timeLimit + 1)
        {
            for (int i = 0; i < shards.Count; i++)
            {
                //shards[i].localRotation = Quaternion.Lerp(shards[i].localRotation, rotationDir, Time.deltaTime * rotation);
                shards[i].Rotate(0, 0, rotation * Time.deltaTime * rotationDir);
                shards[i].Translate(direcoes[i].normalized * fragmentSpeed * Time.deltaTime);
                fragmentSpeed = Mathf.Clamp(fragmentSpeed - deceleration * Time.deltaTime, 0, float.PositiveInfinity);
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
