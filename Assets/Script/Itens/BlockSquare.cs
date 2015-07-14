using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BlockSquare : MonoBehaviour 
{
	public List<string> tagsBlock;
    public float invokingTime;
	public SpriteRenderer sprite;
    bool selectColorOK = true;
    Color cor;
    public GameObject lockedBlock = null;
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

    public void StartInvoking(GameObject block)
    {
        StartCoroutine(InvokeBlock(block));
    }

    public IEnumerator InvokeBlock(GameObject block)
    {
        while (Time.timeScale == 0)
        {
            yield return new WaitForEndOfFrame();
        }
        if (lockedBlock == block)
        {
            var particles = GetComponentInChildren<ParticleSystem>();
            particles.Play();
            block.transform.position = transform.position;
            yield return new WaitForSeconds(invokingTime);
            UnlockBlock(block);
            var blockMovement = block.GetComponent<MovMouse>();
            blockMovement.squaresUnderBlock.Add(gameObject);
            blockMovement.quadradoSelecionado = gameObject;
            blockMovement.pode = true;
            particles.Stop();
            
        }
        yield return null;
    }


    public bool LockBlock(GameObject block, bool force = false)
    {
		if (force) 
		{
			lockedBlock = block;
		}
        else if (lockedBlock != null || blockStack > 0) 
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
            blockStack--;
    }


    public bool CanLand()
    {
        return blockStack == 1 && lockedBlock == null;
    }
}