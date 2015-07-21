using UnityEngine;
using System.Collections;

public class AtivaDesativa : MonoBehaviour
{	
	public Animator[] anim;
	public Animator[] anim3;

	public AudioClip audio;

	int x;

	public void ControllAnim(Animator anim2)
	{
		if(Time.timeScale == 1)
		{
			anim2.SetTrigger("Desclico");
			for(int i = 0; i < anim.Length; i++)
			{
				anim[i].SetTrigger("Desclico");
			}
			for(int i = 0; i < anim3.Length; i++)
			{
				anim3[i].SetTrigger("Desclico");
			}
			x = 0;
		}
		else
		{
			StartCoroutine("Va");
			anim2.SetTrigger("Clico");
		}
	}

	public IEnumerator Va()
	{
		float start = Time.realtimeSinceStartup;

		while (Time.realtimeSinceStartup < start + 0.5f)
		{
			yield return null;
		}
		start = Time.realtimeSinceStartup;
		anim[x].SetTrigger("Clico");

		print("PORRRRAAAAAAA");

		Time.timeScale = 1f;
		AudioSource.PlayClipAtPoint (audio, transform.position);
		Time.timeScale = 0;

		x++;
		StartCoroutine ("Vo");
		StopCoroutine ("Va");
	}

	public IEnumerator Vo()
	{
		float start = Time.realtimeSinceStartup;
		
		while (Time.realtimeSinceStartup < start + 0.5f)
		{
			yield return null;
		}
		start = Time.realtimeSinceStartup;
		anim[x].SetTrigger("Clico");
		
		print("PORRRRAAAAAAA");
		
		Time.timeScale = 1f;
		AudioSource.PlayClipAtPoint (audio, transform.position);
		Time.timeScale = 0;
		
		x++;
		StartCoroutine ("Va");
		StopCoroutine ("Vo");
	}

	public void AD(GameObject obj)
	{
		if(obj.active)
		{
			obj.SetActive(false);
			Time.timeScale = 1;
		}
		else
		{
			obj.SetActive(true);
			Time.timeScale = 0;
		}
	}
}
