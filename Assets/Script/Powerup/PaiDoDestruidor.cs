using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class PaiDoDestruidor : MonoBehaviour 
{

	public List<string> tagsBlock;

	public BoxCollider2D circle;

	public Destruidor dest;

	GameObject objeto;

	AreaDestroy quebra;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			Vector2 pos = new Vector2();
			pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			transform.position = new Vector3(pos.x, pos.y, 0);
		}
		if(objeto != null)
		{
			transform.position = objeto.transform.position;
			circle.enabled = true;
			dest.StartCoroutine("GO");
			quebra = GameObject.FindGameObjectWithTag("Quebra").GetComponent<AreaDestroy>();
			quebra.Volta();
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(tagsBlock.Any(tag => tag == collision.gameObject.tag))
		{
			objeto = collision.gameObject;
		}
	}
	
	void OnTriggerEnter2D(Collider2D collision)
	{
		if(tagsBlock.Any(tag => tag == collision.gameObject.tag))
		{
			objeto = collision.gameObject;
		}
	}
}
