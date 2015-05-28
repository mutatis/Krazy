using UnityEngine;
using System.Collections;
using System.Linq;

public class MovMouse : MonoBehaviour 
{
//	public Colisao col;
	public GameObject tiro;

	public BoxCollider2D box;

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
		box.isTrigger = true;
		if(PlayerPrefs.GetInt("Click") == 0)
		{
			follow = true;
			PlayerPrefs.SetInt("Click", 1);
		}
	}

	void OnMouseUp()
	{
		box.isTrigger = false;
		Instantiate (tiro, transform.position, transform.rotation);
		follow = false;
		PlayerPrefs.SetInt ("Click", 0);
		//col.Attack (1f, 5);
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
