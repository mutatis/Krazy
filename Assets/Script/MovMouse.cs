using UnityEngine;
using System.Collections;
using System.Linq;

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
		if(PlayerPrefs.GetInt("Click") == 0)
		{
			follow = true;
			PlayerPrefs.SetInt("Click", 1);
		}
	}

	void OnMouseUp()
	{
		follow = false;
		PlayerPrefs.SetInt ("Click", 0);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		posFix = collision.gameObject.transform.position;
		print (collision.gameObject.name);
	}
	
	void OnTriggerEnter2D(Collider2D collision)
	{
		posFix = collision.gameObject.transform.position;
		print (collision.gameObject.name);
	}
}
