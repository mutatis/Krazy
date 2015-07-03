using UnityEngine;
using System.Collections;

public class KillController : MonoBehaviour 
{

	public MovMouse mouse;

	public void Cancela()
	{
		print("PORRA");
		if(mouse.life > 1)
		{
			mouse.life --;
			gameObject.GetComponent<Animator>().SetTrigger("Normal");
		}
		//mouse.life --;
	}

	public void Kill()
	{
		mouse.Kill ();
	}
}
