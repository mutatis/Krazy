using UnityEngine;
using System.Collections;

public class KillController : MonoBehaviour 
{

	public MovMouse mouse;
	public bool ok = true;

	public void Cancela()
	{
		print("PORRA");
		if(mouse.life == 1 && ok)
		{
			gameObject.GetComponent<Animator>().SetTrigger("Kill");
			ok = !ok;
		}
		if(mouse.life > 1)
		{
			mouse.life --;
		}
		//mouse.life --;
	}

	public void Kill()
	{
		mouse.Kill ();
	}
}
