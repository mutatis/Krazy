using UnityEngine;
using System.Collections;

public class MovMouse : MonoBehaviour 
{

	bool follow;
	Vector2 pos;
	Vector2 posFix;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		if(follow)
		{
			transform.position = new Vector3(pos.x, pos.y, 0);
		}
		else
		{
			transform.position = posFix;
		}
	}

	void OnMouseDown()
	{
		follow = true;
	}

	void OnMouseUp()
	{
		follow = false;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		posFix = collision.gameObject.transform.position;
		print (collision.gameObject.tag);
	}
	
	void OnTriggerEnter2D(Collider2D collision)
	{
		posFix = collision.gameObject.transform.position;
		print (collision.gameObject.tag);
	}
}
