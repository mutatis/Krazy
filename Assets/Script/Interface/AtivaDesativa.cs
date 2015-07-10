using UnityEngine;
using System.Collections;

public class AtivaDesativa : MonoBehaviour
{	
	public Animator[] anim;
	public Animator[] anim3;
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
		}
		else
		{
			anim2.SetTrigger("Clico");
		}
	}

	public IEnumerator Va()
	{
		float start = Time.realtimeSinceStartup;
		if(x == 0)
		{
			anim[x].SetTrigger("Clico");
		}
		while (Time.realtimeSinceStartup < start + 0.5f)
		{
			yield return null;
		}
		if(x != 0)
		{
			anim[x].SetTrigger("Clico");
		}
		x++;
		StartCoroutine ("Va");
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
