using UnityEngine;
using System.Collections;

public class AnimatorControllerFogo : MonoBehaviour 
{
	public Animator anim;

	public void Pode()
	{
		anim.SetTrigger("Clico");
	}
}
