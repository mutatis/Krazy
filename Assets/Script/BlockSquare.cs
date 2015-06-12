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
        if(blockStack > 0)
		{
			print("print");
            blockStack--;
		}
    }


    public bool CanLand()
    {
        return blockStack == 1;
    }
}