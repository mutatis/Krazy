using UnityEngine;
using System.Collections;

public class LoadingRetry : MonoBehaviour 
{
	public void Retry()
	{
		Application.LoadLevel("Loading");
	}
}
