using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MovMouse : MonoBehaviour 
{
	public GameObject tiro;
    public GameObject quadradoSelecionado;

	public CircleCollider2D box;

	public int quant = 3;

	public bool pode = false;
	public bool playingAnimation;

	public AudioClip[] soundFX;

	float dist;
	
	Vector3 direction2;
	Vector3 posInicial;	
	//Vector3 velocity = Vector3.zero;

   	bool canLand = false; 
  	bool verifica = true;
	//bool anim;

    public List<GameObject> squaresUnderBlock;

	public void Kill()
	{
        box.enabled = false;
        quadradoSelecionado.SendMessage("OnDeselect");
        pode = false;
        print("Killed, stack: " + quadradoSelecionado.GetComponent<BlockSquare>().blockStack.ToString());
	}

	public void Destroy()
	{
		Score.score.Ponto (1);
		Destroy(gameObject);
	}

	public void Down()
	{
        if (!playingAnimation && pode)
        {
			AudioSource.PlayClipAtPoint(soundFX[0], transform.position, 1);
			StartCoroutine("MovingBlock");
            if (PlayerPrefs.GetInt("Click") == 0)
            {
                PlayerPrefs.SetInt("Click", 1);
            }
        }
	}

	public void Up()
	{
        if (!playingAnimation && pode)
        {
            if (canLand && quadradoSelecionado != null)
            {
				AudioSource.PlayClipAtPoint(soundFX[1], transform.position, 1); //som de erro
                StopCoroutine("MovingBlock");
                transform.position = quadradoSelecionado.transform.position;
                GameObject tempObj = Instantiate(tiro, transform.position, transform.rotation) as GameObject;
				tempObj.GetComponent<Lista>().quant = quant;
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
		Vector2 pos = new Vector2();
        var quadradoSelecionadoInicial = quadradoSelecionado;
        quadradoSelecionadoInicial.SendMessage("LockBlock", gameObject);
        while (verifica)
        {
			pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            transform.position = new Vector3(pos.x, pos.y, 0);            
            canLand = CheckSelectedSquare();
            yield return new WaitForEndOfFrame();
        }
		verifica = true;
		//se chegamos até aqui, é porque o bloco não pode ser soltado na posição desejada.
        GetComponent<Block>().SetTarget(quadradoSelecionadoInicial);

    } 

	void Segue()
	{		
		AudioSource.PlayClipAtPoint(soundFX[2], transform.position, 0.3f);
        //transform.position = posInicial;
	}

 	public bool CheckSelectedSquare()
    {        
        var candidato = squaresUnderBlock.OrderBy(d => Vector3.Distance(transform.position, d.transform.position)).FirstOrDefault();
        if (quadradoSelecionado != candidato && quadradoSelecionado != null) 
        {
            quadradoSelecionado.SendMessage("OnDeselect");
        }
        quadradoSelecionado = candidato;
        quadradoSelecionado.SendMessage("OnSelect");
        return quadradoSelecionado.GetComponent<BlockSquare>().CanLand();
    }

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Grid")
		{
			if(pode)
			{
	            squaresUnderBlock.Add(collision.gameObject);
                collision.gameObject.SendMessage("OnHover");
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
                collision.gameObject.SendMessage("OnExit");
			}
		}
	}

    void OnTriggerStay2D(Collider2D collider)
    {

        if (squaresUnderBlock.Count == 0 && collider.tag == "Grid" && pode)
        {
            squaresUnderBlock.Add(collider.gameObject);
            collider.gameObject.SendMessage("OnHover");
        }
    }

	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Grid")
		{
			if(pode)
			{
	            squaresUnderBlock.Add(collision.gameObject);
                collision.gameObject.SendMessage("OnHover");
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
	            collision.gameObject.SendMessage("OnExit");
			}
		}
	}

}
