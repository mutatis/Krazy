using UnityEngine;
using System.Collections;

public class AtivaDesativa : MonoBehaviour
{	
	public void ControllAnim(Animator anim)
	{
		if(Time.timeScale == 1)
		{
			anim.SetTrigger("Desclico");
		}
		else
		{
			anim.SetTrigger("Clico");
		}
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
