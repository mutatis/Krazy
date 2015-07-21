using UnityEngine;
using System.Collections;

public class AnimatorControllerFogo : MonoBehaviour 
{
	public Animator anim;

	public AudioClip audio;

	public void Fogo()
	{

	}

	public void Pode()
	{
		anim.SetTrigger("Clico");
	}
}