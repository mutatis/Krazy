using UnityEngine;
using System.Collections;

public class CickButton : MonoBehaviour
{

	public void Click(AudioClip audio)
	{
		AudioSource.PlayClipAtPoint (audio, transform.position);
	}
}
