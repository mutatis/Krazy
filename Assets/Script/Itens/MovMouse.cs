using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MovMouse : MonoBehaviour 
{
	public GameObject tiro;
    public GameObject quadradoSelecionado;

	public CircleCollider2D box;

	public bool pode = false;
	public bool playingAnimation;

	float dist;
	
	Vector3 direction2;
	Vector3 posInicial;	
	Vector3 velocity = Vector3.zero;

   	bool canLand = false; 
  	bool verifica = true;
	bool anim;

	Vector2 pos;

	//Vector2 posFix;
    public List<GameObject> squaresUnderBlock;

	void Start () 
	{
		CheckSelectedSquare();
	}

	void Update () 
	{
		pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		if(anim)
		{
			dist = Vector3.Distance(posInicial, transform.position);
			if(dist > 0.1f)
			{
				direction2 = posInicial - transform.position;
				Vector3 destination = transform.position + direction2;
				transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, 0.25f);
			}
			else
			{
				transform.position = posInicial;
				anim = false;
			}
		}
	}

	public void Kill()
	{
		print (quadradoSelecionado.ToString() + Time.time.ToString());
        quadradoSelecionado.GetComponent<BlockSquare>().blockStack--;
		Destroy(gameObject);
	}

	public void Down()
	{
        if (!playingAnimation)
        {
            StartCoroutine("MovingBlock");
           // box.isTrigger = true;
            if (PlayerPrefs.GetInt("Click") == 0)
            {
                PlayerPrefs.SetInt("Click", 1);
            }
        }
	}

	public void Up()
	{
        if (!playingAnimation)
        {
           // box.isTrigger = false;
            if (canLand)
            {
                StopCoroutine("MovingBlock");
                transform.position = quadradoSelecionado.transform.position;
                Instantiate(tiro, transform.position, transform.rotation);
            }
            else
            {
                verifica = false;
            }
            PlayerPrefs.SetInt("Click", 0);
        }
	}

    IEnumerator MovingBlock()
    {
        posInicial = transform.position;
        while (verifica)
        {
            transform.position = new Vector3(pos.x, pos.y, 0);            
            canLand = CheckSelectedSquare();
            yield return new WaitForEndOfFrame();
        }
		verifica = true;
		Segue ();
    } 

	void Segue()
	{		
		anim = true;
        //transform.position = posInicial;
	}

 	bool CheckSelectedSquare()
    {        
        if (quadradoSelecionado)
            quadradoSelecionado.SendMessage("OnRemove");

        quadradoSelecionado = squaresUnderBlock.OrderBy(d => Vector3.Distance(transform.position, d.transform.position)).FirstOrDefault();
        if (quadradoSelecionado != null)
        {
            quadradoSelecionado.SendMessage("OnSelect");
            return quadradoSelecionado.GetComponent<BlockSquare>().CanLand();
        }
        return true;
    }

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Grid")
		{
			if(pode)
			{
				//posFix = collision.gameObject.transform.position;
	            squaresUnderBlock.Add(collision.gameObject);
	            CheckSelectedSquare();
			}
		}
	}

	void OnCollisionExit2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Grid")
		{
			if(pode)
			{
	            squaresUnderBlock.Remove(collision.gameObject);
	            collision.gameObject.SendMessage("OnRemove");
			}
		}
	}

    /*void OnTriggerStay2D(Collider2D collider)
    {

        if (squaresUnderBlock.Count == 0 && collider.tag == "Grid")
        {
            squaresUnderBlock.Add(collider.gameObject);
        }
    }*/

	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Grid")
		{
			if(pode)
			{
	            //posFix = collision.gameObject.transform.position;
	            squaresUnderBlock.Add(collision.gameObject);
	            collision.gameObject.name = "Sprite" + Time.time.ToString();
	            CheckSelectedSquare();
			}
		}
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Grid")
		{
			if(pode)
			{
	            squaresUnderBlock.Remove(collision.gameObject);
	            collision.gameObject.SendMessage("OnRemove");
			}
		}
	}

}
