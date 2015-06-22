using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Destruidor : MonoBehaviour
{
	public List<string> tagsBlock;
	
	public ArrayList obj = new ArrayList();

	public GameObject pai;

	GameObject objeto;
	
	Animator anim;
	
	bool pode;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public IEnumerator GO()
	{
		yield return new WaitForSeconds (0.1f);
		Destroy (pai);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(tagsBlock.Any(tag => tag == collision.gameObject.tag))
		{
			objeto = collision.gameObject;
			if(objeto != null)
			{
				anim = objeto.GetComponentInChildren<Animator>();
				anim.SetTrigger("Kill");
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if(tagsBlock.Any(tag => tag == collision.gameObject.tag))
		{
			objeto = collision.gameObject;
			if(objeto != null)
			{
				anim = objeto.GetComponentInChildren<Animator>();
				anim.SetTrigger("Kill");
			}
		}
	}
}
