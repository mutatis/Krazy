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

	bool follow;
	bool verifica;

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
		if(follow)
		{
			transform.position = new Vector3(pos.x, pos.y, 0);

            CheckSelectedSquare();            
		}
		else
		{
			transform.position = quadradoSelecionado.transform.position;
			if(verifica)
			{
				Instantiate (tiro, transform.position, transform.rotation);
				verifica = false;
			}
		}
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
			follow = true;
			PlayerPrefs.SetInt("Click", 1);
		}
	}

	public void Up()
	{
		box.isTrigger = false;
		follow = false;
		verifica = true;
		PlayerPrefs.SetInt ("Click", 0);
	}

 	void CheckSelectedSquare()
    {        
        if (quadradoSelecionado)
            quadradoSelecionado.SendMessage("OnRemove");

        quadradoSelecionado = squaresUnderBlock.OrderBy(d => Vector3.Distance(transform.position, d.transform.position)).First();
        quadradoSelecionado.SendMessage("OnSelect");
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
