using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MovMouse : MonoBehaviour 
{
	public GameObject tiro;
    public GameObject quadradoSelecionado;
	public CircleCollider2D box;
	public bool pode;

   bool canLand = false; 
   bool verifica = true;

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
	}

	public void Kill()
	{
		Destroy(gameObject);
	}

	public void Down()
	{
		box.isTrigger = true;
		if(PlayerPrefs.GetInt("Click") == 0)
		{
			PlayerPrefs.SetInt("Click", 1);
		}
	}

	public void Up()
	{
		box.isTrigger = false;
        if (canLand) {
            StopCoroutine("MovingBlock");
            Instantiate(tiro, transform.position, transform.rotation);
        }
		PlayerPrefs.SetInt ("Click", 0);
	}

    IEnumerator MovingBlock()
    {
        var posInicial = transform.position;
        while (verifica)
        {
            transform.position = new Vector3(pos.x, pos.y, 0);            
            canLand = CheckSelectedSquare();
            yield return new WaitForEndOfFrame();
        }

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
