using UnityEngine;
using System.Collections;

public class teste : MonoBehaviour 
{
	public Transform pos;

	void Start()
	{
		transform.position = new Vector3 (pos.position.x, transform.position.y, transform.position.z);
	}
}
