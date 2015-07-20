using UnityEngine;
using System.Collections;

public class teste : MonoBehaviour 
{
	public Transform pos;

	public MeshRenderer[] score;

	public Material[] material;

	int x;

	void Start()
	{
		transform.position = new Vector3 (pos.position.x, transform.position.y, transform.position.z);
	}

	void Update()
	{
		if(transform.eulerAngles.x < 150 && x == 1)
		{
			transform.Rotate(10, 0, 0);
		}
		else if(transform.eulerAngles.x > 0 && x == 0)
		{
			transform.Rotate(10, 0, 0);
		}
	}

	public void SetValue(int value)
	{
		if(x == 0)
		{
			score[1].material = material[value];
			x = 1;
		}
		else
		{
			score[0].material = material[value];
			x = 0;
		}

	}
}
