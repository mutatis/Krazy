using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CorCol : MonoBehaviour 
{
	public List<string> tagsBlock;
	public SpriteRenderer sprite;

	public bool ok;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	public void OnSelect()
	{

	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(tagsBlock.Any(tag => tag == collision.gameObject.tag))
		{
			ok = false;
		}
	}

	void OnCollisionStay2D(Collision2D collision)
	{
		if(tagsBlock.Any(tag => tag == collision.gameObject.tag))
		{
			ok = false;
		}
	}
	
	void OnCollisionExit2D(Collision2D collision)
	{
		if(tagsBlock.Any(tag => tag == collision.gameObject.tag))
		{
			ok = true;
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if(tagsBlock.Any(tag => tag == collision.gameObject.tag))
		{
			ok = false;
		}
	}
	
	void OnTriggerStay2D(Collider2D collision)
	{
		if(tagsBlock.Any(tag => tag == collision.gameObject.tag))
		{
			ok = false;
		}
	}
	
	void OnTriggerExit2D(Collider2D collision)
	{
		if(tagsBlock.Any(tag => tag == collision.gameObject.tag))
		{
			ok = true;
		}
	}
}
