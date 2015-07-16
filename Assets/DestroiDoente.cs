using UnityEngine;
using System.Collections;

public class DestroiDoente : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		StartCoroutine("GO");
	}

	IEnumerator GO()
	{
		yield return new WaitForSeconds (1);
		Destroy (gameObject);
	}
}
