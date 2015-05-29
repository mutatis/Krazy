using UnityEngine;
using System.Collections;
using System.Linq;

public class MovMouse : MonoBehaviour 
{
	public GameObject tiro;

	public CircleCollider2D box;

	bool follow;
	bool verifica;

	Vector2 pos;
	Vector2 posFix;

	void Start () 
	{
	
	}

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
			if(verifica)
			{
				Instantiate (tiro, transform.position, transform.rotation);
				verifica = false;
			}
		}
	}

	public void Down()
	{
		box.isTrigger = true;
		if(PlayerPrefs.GetInt("Click") == 0)
		{
			follow = true;
			PlayerPrefs.SetInt("Click", 1);
		}
	}

	public void Up()
	{
		box.isTrigger = false;
		follow = false;
		verifica = true;
		PlayerPrefs.SetInt ("Click", 0);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Grid")
		{
			posFix = collision.gameObject.transform.position;
		}
	}
	
	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Grid")
		{
			posFix = collision.gameObject.transform.position;
		}
	}
}
