using UnityEngine;
using System.Collections;

public class Direcao : MonoBehaviour 
{

	public float velX;
	public float velY;

	public int tipo;

	public string tag;

	public Lista lista;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine("Go");
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (velX * Time.deltaTime, velY * Time.deltaTime, 0);
	}

	IEnumerator Go()
	{
		yield return new WaitForSeconds (0.4f);
		lista.x ++;
		Destroy (gameObject);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == tag)
		{
			StopCoroutine("Go");
			if(tipo == 1)
			{
				lista.obj.Add (collision.gameObject);
			}
			else if(tipo == 2)
			{
				lista.obj2.Add (collision.gameObject);
			}
			StartCoroutine("Go");
		}
	}
	
	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == tag)
		{
			StopCoroutine("Go");
			if(tipo == 1)
			{
				lista.obj.Add (collision.gameObject);
			}
			else if(tipo == 2)
			{
				lista.obj2.Add (collision.gameObject);
			}
			StartCoroutine("Go");
		}
	}
}
