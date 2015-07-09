using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MovMouse : MonoBehaviour 
{
	public int quant = 3;
	//public int life = 2;

	public bool ancora;
    public bool mouseDown;
    public bool pode = false;
	public bool playingAnimation;
	public int Touch; 

    bool canLand = false;
    bool verifica = true;
	
	GameObject quadradoTemp;

    public GameObject tiro;
    public GameObject quadradoSelecionado;

    public AudioClip[] soundFX;

    public List<GameObject> squaresUnderBlock;

    public SceneMaster sceneMaster;

    void Start()
    {
        sceneMaster = GameObject.FindGameObjectWithTag("SceneMaster").GetComponent<SceneMaster>();

		int x = Random.Range (0, 5);

		/*if(x == 4)
		{
			ancora = true;
		}*/

	/*	if(x == 1)
		{
			life = 2;
		}*/
    }

	public void Desliga()
	{
		gameObject.GetComponent<CircleCollider2D>().enabled = false;
		ancora = true;
	}

	public void Kill()
	{
		if(quadradoSelecionado)
		{
        	quadradoSelecionado.SendMessage("OnExit");
		}

        pode = false;
		print("kill");
        SendMessage("OnKill");
	}

	public void Down()
	{
		if(!ancora && Time.timeScale != 0)
		{
	        if (!playingAnimation && pode)
	        {
				AudioSource.PlayClipAtPoint(soundFX[0], transform.position, 1);
				StartCoroutine("MovingBlock");
				if (PlayerPrefs.GetInt("Click") == 0)
				{
					PlayerPrefs.SetInt("Click", 1);
				}
	            //evitar situações em que o evento de Up() é disparado sem o Down().
	            mouseDown = true;
	        }
		}
	}

	public void Up()
	{
        //print("up");
		if(!ancora)
		{
            //print("up2");
	        //Checa pelo scene master caso o bloco seja solto após o game over.
            if (!playingAnimation && pode && mouseDown && sceneMaster.enabled)
            {
                mouseDown = false;
                if (canLand && quadradoSelecionado != null)
                {
                    quadradoTemp.SendMessage("UnlockBlock", gameObject);
                    AudioSource.PlayClipAtPoint(soundFX[1], transform.position, 1); //som de erro
                    StopCoroutine("MovingBlock");
                    transform.position = quadradoSelecionado.transform.position;
                    GameObject tempObj = Instantiate(tiro, transform.position, transform.rotation) as GameObject;
                    tempObj.GetComponent<Lista>().quant = quant;
                }
                else
                {
                    quadradoSelecionado = quadradoTemp;
                    verifica = false;
                }
            }
			//PlayerPrefs.SetInt("Click", 0);
		}
	}

    IEnumerator MovingBlock()
    {
        transform.SetAsLastSibling(); //ensure it's on top of everybody
		Vector2 pos = new Vector2();
        quadradoTemp = quadradoSelecionado;
		quadradoTemp.GetComponent<BlockSquare> ().LockBlock (gameObject, true);
        Vector3 touchPosition;    
        while (verifica)
        {
			try
			{
				touchPosition = Input.GetTouch(0).position;
			}
			catch
			{
				touchPosition = Input.mousePosition;
			}
			pos = Camera.main.ScreenToWorldPoint (touchPosition);
            transform.position = new Vector3(pos.x, pos.y, 0);            
            canLand = CheckSelectedSquare();
            yield return new WaitForEndOfFrame();
        }
		verifica = true;
		//se chegamos até aqui, é porque o bloco não pode ser soltado na posição desejada.
		quadradoSelecionado.SendMessage("OnExit");
		var _squares = new List<GameObject> (squaresUnderBlock);
		foreach (var square in _squares) 
		{
			square.SendMessage("OnExit");
			squaresUnderBlock.Remove(square);
		}
        GetComponent<Block>().SetTarget(quadradoTemp);
    } 

 	public bool CheckSelectedSquare()
    {        
        var candidato = squaresUnderBlock.OrderBy(d => Vector3.Distance(transform.position, d.transform.position)).FirstOrDefault();
        if (quadradoSelecionado != candidato && quadradoSelecionado != null) 
        {
            quadradoSelecionado.SendMessage("OnDeselect");
        }
        quadradoSelecionado = candidato;
        if (quadradoSelecionado)
        {
            quadradoSelecionado.SendMessage("OnSelect");
            return quadradoSelecionado.GetComponent<BlockSquare>().CanLand();
        }
        else
            return false;        
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
			if(pode && squaresUnderBlock.Remove(collision.gameObject))
			{
	            collision.gameObject.SendMessage("OnExit");
			}
		}
	}

}