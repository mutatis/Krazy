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
    public GameObject lockedBlock;
    public int blockStack = 0;
    //public List<GameObject> blocksOverSquare;


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

    public bool LockBlock(GameObject block)
    {
        if (lockedBlock != null || blockStack > 0) 
        {
            return false;
        }
        else
            lockedBlock = block;
        return true;
    }

    public void UnlockBlock(GameObject key)
    {
        if (lockedBlock == key)
            lockedBlock = null;
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
        //print(transform.parent.name);
        if(blockStack > 0)
            blockStack--;

    }


    public bool CanLand()
    {
        print("printoso");
        return blockStack == 1 && lockedBlock == null;
    }

    	/*void OnCollisionEnter2D(Collision2D collision)
	{
		if(tagsBlock.Any(t => t == collision.gameObject.tag))
		{
			if(pode)
			{
	            blocksOverSquare.Add(collision.gameObject);
                collision.gameObject.SendMessage("OnHover");
			}
		}
	}

	void OnCollisionExit2D(Collision2D collision)
	{
		if(tagsBlock.Any(t => t == collision.gameObject.tag))
		{
	            blocksOverSquare.Remove(collision.gameObject);
		}
	}

    void OnTriggerStay2D(Collider2D collider)
    {

        if (blocksOverSquare.Count == 0 && tagsBlock.Any(t => t == collider.gameObject.tag))
        {
            blocksOverSquare.Add(collider.gameObject);
            collider.gameObject.SendMessage("OnHover");
        }
    }

	void OnTriggerEnter2D(Collider2D collision)
	{
		if(tagsBlock.Any(t => t == collision.gameObject.tag))
		{
	            blocksOverSquare.Add(collision.gameObject);
                collision.gameObject.SendMessage("OnHover");
		}
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		if(tagsBlock.Any(t => t == collision.gameObject.tag))
		{
	            blocksOverSquare.Remove(collision.gameObject);
	            collision.gameObject.SendMessage("OnExit");
		}
	}

}*/
}