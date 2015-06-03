using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lista : MonoBehaviour
{

	public ArrayList obj = new ArrayList();
	public ArrayList obj2 = new ArrayList();

	public AudioClip somPontuacao;

	public int x;

	GameObject objeto;

	Animator anim;

	bool toca;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine("GO");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(x == 4)
		{
			if(obj.Count > 3)
			{
				if(!toca)
				{
					AudioSource.PlayClipAtPoint(somPontuacao, transform.position, 1);
					toca = true;
				}
				for(int i = 0; i < obj.Count; i++)
				{
					objeto = (GameObject)obj[i];
					if(objeto != null)
					{
						anim = objeto.GetComponent<Animator>();
						anim.SetTrigger("Kill");
					}
					//Destroy ((GameObject)obj[i]);
				}
			}
			if(obj2.Count > 3)
			{
				if(!toca)
				{
					AudioSource.PlayClipAtPoint(somPontuacao, transform.position, 1);
					toca = true;
				}
				for(int i = 0; i < obj2.Count; i++)
				{
					objeto = (GameObject)obj2[i];
					if(objeto != null)
					{
						anim = objeto.GetComponent<Animator>();
						anim.SetTrigger("Kill");
					}
					//Destroy ((GameObject)obj2[i]);
				}
			}
			if(obj2.Count <= 3 && obj.Count <= 3)
			{
				Destroy(gameObject);
			}
		}
	}

	IEnumerator GO()
	{
		yield return new WaitForSeconds(6);
		Destroy(gameObject);
	}
}