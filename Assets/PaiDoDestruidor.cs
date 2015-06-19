using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PaiDoDestruidor : MonoBehaviour 
{

	public List<string> tagsBlock;

	public CircleCollider2D circle;

	public Destruidor dest;

	GameObject objeto;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			Vector2 pos = new Vector2();
			pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			transform.position = new Vector3(pos.x, pos.y, 0);
			StartCoroutine("GO");
		}
		if(objeto.GetComponent<MovMouse>().mouseDown)
		{
			transform.position = objeto.transform.position;
			circle.enabled = true;
			dest.StartCoroutine("GO");
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(tagsBlock.Any(tag => tag == collision.gameObject.tag))
		{
			objeto = collision.gameObject;
		}
	}
	
	void OnTriggerEnter2D(Collider2D collision)
	{
		if(tagsBlock.Any(tag => tag == collision.gameObject.tag))
		{
			objeto = collision.gameObject;
		}
	}
}
