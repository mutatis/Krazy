using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour 
{

	public AudioClip[] sons;

	public void Morte()
	{
		AudioSource.PlayClipAtPoint(sons[0], transform.position, 0.2f);
	}
}