using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CorCol : MonoBehaviour 
{
	public List<string> tagsBlock;
	public SpriteRenderer sprite;
    bool selectColorOK = true;
    Color cor;

    // Use this for initialization
    void Start()
    {
        cor = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButton(0) && selectColorOK)
        {
            sprite.color = cor;
            selectColorOK = false;
        }
    }
	public bool ok;

	// Use this for initialization
	
	// Update is called once per frame

	public void OnSelect()
	{
        sprite.color = Color.white;
        selectColorOK = true;
	}

    public void OnRemove() 
    {
        sprite.color = cor;
        selectColorOK = true;
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

/*using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CorCol : MonoBehaviour 
{
	public List<string> tagsBlock;
	Color cor;
	public SpriteRenderer sprite;
    bool selectColorOK = true;
	

	// Use this for initialization
	void Start ()
	{
		cor = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a);	
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (!Input.GetMouseButton(0) && selectColorOK)
        {
            sprite.color = cor;
            selectColorOK = false;
        }
	}

	public void OnSelect()
	{
        sprite.color = Color.white;
        selectColorOK = true;
	}

	public void OnRemove()
	{
        sprite.color = cor;
        selectColorOK = true;
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
            sprite.color = new Color(cor.r, cor.g, cor.b, cor.a);
		}
	}
}
*/