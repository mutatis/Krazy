using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lista : MonoBehaviour
{

	public ArrayList obj = new ArrayList();
	public ArrayList obj2 = new ArrayList();

	public AudioClip[] somPontuacao;

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
					switch(obj.Count)
					{
					case 3:
						AudioSource.PlayClipAtPoint(somPontuacao[0], transform.position, 1);
						break;
						
					case 4:
						AudioSource.PlayClipAtPoint(somPontuacao[1], transform.position, 1);
						break;
						
					case 5:
						AudioSource.PlayClipAtPoint(somPontuacao[2], transform.position, 1);
						break;
						
					case 6:
						AudioSource.PlayClipAtPoint(somPontuacao[3], transform.position, 1);
						break;
						
					case 7:
						AudioSource.PlayClipAtPoint(somPontuacao[4], transform.position, 1);
						break;
						
					case 8:
						AudioSource.PlayClipAtPoint(somPontuacao[5], transform.position, 1);
						break;
						
					default:
						AudioSource.PlayClipAtPoint(somPontuacao[6], transform.position, 1);
						break;
					}
					toca = true;
				}
				for(int i = 0; i < obj.Count; i++)
				{
					objeto = (GameObject)obj[i];
					if(objeto != null)
					{
						anim = objeto.GetComponentInChildren<Animator>();
						anim.SetTrigger("Kill");
					}
					//Destroy ((GameObject)obj[i]);
				}
			}

			if(obj2.Count > 3)
			{
				if(!toca)
				{
					switch(obj2.Count)
					{
						case 3:
							AudioSource.PlayClipAtPoint(somPontuacao[0], transform.position, 1);
						break;

						case 4:
							AudioSource.PlayClipAtPoint(somPontuacao[1], transform.position, 1);
						break;

						case 5:
							AudioSource.PlayClipAtPoint(somPontuacao[2], transform.position, 1);
						break;

						case 6:
							AudioSource.PlayClipAtPoint(somPontuacao[3], transform.position, 1);
						break;

						case 7:
							AudioSource.PlayClipAtPoint(somPontuacao[4], transform.position, 1);
						break;

						case 8:
							AudioSource.PlayClipAtPoint(somPontuacao[5], transform.position, 1);
						break;

						default:
							AudioSource.PlayClipAtPoint(somPontuacao[6], transform.position, 1);
						break;
					}
					toca = true;
				}
				for(int i = 0; i < obj2.Count; i++)
				{
					objeto = (GameObject)obj2[i];
					if(objeto != null)
					{
						anim = objeto.GetComponentInChildren<Animator>();
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