using UnityEngine;
using System.Collections;

public class KillController : MonoBehaviour 
{

	public MovMouse mouse;

	public Animator anim;

	public void Kill()
	{
		mouse.Kill ();
	}
}
