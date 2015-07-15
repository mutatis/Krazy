using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lista : MonoBehaviour
{

	public ArrayList obj = new ArrayList();
	public ArrayList obj2 = new ArrayList();

	public AudioClip[] somPontuacao;

	public D2D_ClickToSpawn camera;

	public int x;
	public int quant = 3;

	GameObject objeto;

	Animator anim;

	bool toca;

	// Use this for initialization
	void Start ()
	{
		camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<D2D_ClickToSpawn> ();
		StartCoroutine("GO");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(x == 4)
		{
			if(obj.Count > quant + 1 && obj2.Count > quant + 1)
			{
				print(obj.Count + " " + obj2.Count);
				int temp;
				temp = obj.Count + obj2.Count;
				if(!toca)
				{
					switch(temp)
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
						camera.Atira(objeto.transform.position);
						anim = objeto.GetComponentInChildren<Animator>();
						anim.SetTrigger("Kill");
					}
					//Destroy ((GameObject)obj[i]);
				}

				for(int i = 0; i < obj2.Count; i++)
				{
					objeto = (GameObject)obj2[i];
					
					if(objeto != null)
					{
						camera.Atira(objeto.transform.position);
						anim = objeto.GetComponentInChildren<Animator>();
						anim.SetTrigger("Kill");
					}
					//Destroy ((GameObject)obj2[i]);
				}
			}
			if(obj.Count > quant)
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
						camera.Atira(objeto.transform.position);
						anim = objeto.GetComponentInChildren<Animator>();
						anim.SetTrigger("Kill");
					}
					//Destroy ((GameObject)obj[i]);
				}
			}
			if(obj2.Count > quant)
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
						camera.Atira(objeto.transform.position);
						anim = objeto.GetComponentInChildren<Animator>();
						anim.SetTrigger("Kill");
					}
					//Destroy ((GameObject)obj2[i]);
				}
			}

			if(obj2.Count <= quant && obj.Count <= quant)
			{
				Destroy(gameObject);
			}
			x = 0;
		}
	}

	IEnumerator GO()
	{
		yield return new WaitForSeconds(6);
		Destroy(gameObject);
	}
}