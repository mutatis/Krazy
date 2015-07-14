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
    private GameObject sceneMaster;
    private MouseInteraction mouseInteraction;
    private bool selected;


    // Use this for initialization
    void Start()
    {
        cor = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a);
        sceneMaster = GameObject.FindGameObjectWithTag("SceneMaster");
        mouseInteraction = sceneMaster.GetComponent<MouseInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && selected)
        {
            sceneMaster.SendMessage("OnClickSquare", gameObject);
            OnDeselect();
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
            //UnlockBlock(block);
            /*var blockMovement = block.GetComponent<MovMouse>();
            blockMovement.squaresUnderBlock.Add(gameObject);
            blockMovement.quadradoSelecionado = gameObject;
            blockMovement.pode = true;*/
            particles.Stop();
            
        }
        yield return null;
    }


    public bool LockBlock(GameObject block, bool force = false)
    {
		if (force) 
		{
			lockedBlock = block;
            block.GetComponent<BlockMovement>().lockedSquare = gameObject;
		}
        else if (lockedBlock != null /*|| blockStack > 0*/) 
        {
            return false;
        }
        else
        {
            lockedBlock = block;
            block.GetComponent<BlockMovement>().lockedSquare = gameObject;
        }
			
        return true;
    }

    public void UnlockBlock(GameObject key)
    {
        if (lockedBlock == key)
        {
            lockedBlock = null;
            key.GetComponent<BlockMovement>().lockedSquare = null;
        }
            
    }

	public void OnSelect()
	{
        sprite.color = Color.white;
        selected = true;
	}

    public void OnDeselect()
    {
        sprite.color = cor;
        selected = false;
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

    void OnMouseEnter()
    {
        if(!lockedBlock && mouseInteraction.HasSelected)
            OnSelect();
    }

    void OnMouseExit()
    {
        OnDeselect();
    }
}