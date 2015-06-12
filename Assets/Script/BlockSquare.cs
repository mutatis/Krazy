using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BlockSquare : MonoBehaviour 
{
	public List<string> tagsBlock;
	public SpriteRenderer sprite;
    bool selectColorOK = true;
    Color cor;
	public bool ok = true;
    public int blockStack = 0;

    // Use this for initialization
    void Start()
    {
        cor = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (blockStack < 0 || ok)
        {
            blockStack = 0;
        }*/

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

    public void OnDeselect()
    {
        sprite.color = cor;
        selectColorOK = true;
    }

    public void OnHover()
    {
        blockStack++;
    }

    public void OnExit() 
    {
        blockStack--;
    }


    public bool CanLand()
    {
        return blockStack == 1;
    }

	/*void OnCollisionEnter2D(Collision2D collision)
	{
		if(tagsBlock.Any(tag => tag == collision.gameObject.tag))
		{
            print("++");
			blockStack ++;
			ok = false;
		}
	}

	void OnCollisionStay2D(Collision2D collision)
	{
		if(tagsBlock.Any(tag => tag == collision.gameObject.tag))
		{
			ok = false;
		}
		else
		{
			ok = true;
		}
	}
	
	void OnCollisionExit2D(Collision2D collision)
	{
		if(tagsBlock.Any(tag => tag == collision.gameObject.tag))
		{
            print("--");
			blockStack --;
            if (blockStack == 0)
                ok = true;
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if(tagsBlock.Any(tag => tag == collision.gameObject.tag))
		{
            print("++");
			blockStack ++;
			ok = false;
		}
	}
	
	void OnTriggerStay2D(Collider2D collision)
	{
		if(tagsBlock.Any(tag => tag == collision.gameObject.tag))
		{
            ok = false;
		}
		else
		{
			ok = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D collision)
	{
		if(tagsBlock.Any(tag => tag == collision.gameObject.tag))
		{
			blockStack --;
            if(blockStack == 0)
			    ok = true;
		}
	}*/
}