using UnityEngine;
using System.Collections;

public class MovCircle : MonoBehaviour 
{
	public Vector2 direction;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (direction.x, direction.y, 0);
	}
}
