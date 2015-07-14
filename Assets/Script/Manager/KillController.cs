using UnityEngine;
using System.Collections;

public class KillController : MonoBehaviour 
{

	//public MouseInteraction mouse;

	public void Desativa()
	{
        transform.parent.GetComponent<CircleCollider2D>().enabled = false;
	}

	public void Cancela()
	{
		/*if(mouse.life > 1)
		{
			mouse.life --;
			gameObject.GetComponent<Animator>().SetTrigger("Normal");
		}*/
	}

	public void Kill()
	{
        SendMessageUpwards("OnKill");
	}
}
