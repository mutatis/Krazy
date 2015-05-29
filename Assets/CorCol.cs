using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CorCol : MonoBehaviour 
{
	public List<string> tagsBlock;
	Color cor;
	public SpriteRenderer sprite;

	bool ok;

	// Use this for initialization
	void Start ()
	{
		cor = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a);	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(ok)
		{
			if(sprite.color != cor)
			{
				sprite.color = new Color(cor.r, cor.g, cor.b, cor.a);
			}
			else
			{
				ok = false;
			}
		}
	}

	public void White()
	{

	}

	public void Normal()
	{

	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(tagsBlock.Any(tag => tag == collision.gameObject.tag))
		{
			sprite.color = Color.white;
		}
	}
	
	void OnCollisionExit2D(Collision2D collision)
	{
		if(tagsBlock.Any(tag => tag == collision.gameObject.tag))
		{
			ok = true;
			sprite.color = new Color(cor.r, cor.g, cor.b, cor.a);
		}
	}
	
	void OnTriggerEnter2D(Collider2D collision)
	{
		if(tagsBlock.Any(tag => tag == collision.gameObject.tag))
		{
			sprite.color = Color.white;
		}
	}
	
	void OnTriggerExit2D(Collider2D collision)
	{
		if(tagsBlock.Any(tag => tag == collision.gameObject.tag))
		{
			ok = true;
			sprite.color = new Color(cor.r, cor.g, cor.b, cor.a);
		}
	}
}
