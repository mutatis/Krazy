﻿using UnityEngine;
using System.Collections;

public class KillController : MonoBehaviour 
{

	public MovMouse mouse;

	public void Desativa()
	{
//		if(mouse.life <= 1)
//{
			mouse.Desliga();
		//}
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
		mouse.Kill ();
	}
}
