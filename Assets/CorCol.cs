using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CorCol : MonoBehaviour 
{
	public List<string> tagsBlock;
	public Color cor;
    public SpriteRenderer sprite;
    bool ok;
	public bool selected;

    bool 

	// Use this for initialization
	void Start ()
	{
		cor = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a);	
	}
	
	// Update is called once per frame
    public void Update()
    {
        if (!Input.GetMouseButton(0))
        {

        }
    }

	public void OnSelect()
	{
        sprite.color = Color.white;
	}

	public void OnRemove()
	{
        sprite.color = cor;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(tagsBlock.Any(tag => tag == collision.gameObject.tag))
		{
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
