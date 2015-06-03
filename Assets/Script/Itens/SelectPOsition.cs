using UnityEngine;
using System.Collections;

public class SelectPOsition : MonoBehaviour 
{

	private Vector3 direction2;

	public MovMouse mouse;

	private Vector3 velocity = Vector3.zero;

	float dist;

	bool pare;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		if(!pare)
		{
			mouse.quadradoSelecionado = (GameObject)CreatedObj.creat.grid[CreatedObj.creat.gridRandom];
			dist = Vector3.Distance(CreatedObj.creat.grid[CreatedObj.creat.gridRandom].transform.position, transform.position);
			if(dist > 0.001f)
			{
				direction2 = (CreatedObj.creat.grid[CreatedObj.creat.gridRandom].transform.position - transform.position);
				Vector3 destination = transform.position + direction2;
				transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, 0.25f);
			}
			else
			{
				mouse.quadradoSelecionado = (GameObject)CreatedObj.creat.grid[CreatedObj.creat.gridRandom];
				mouse.enabled = true;
				mouse.pode = true;
				pare = true;
			}
		}
	}
}
