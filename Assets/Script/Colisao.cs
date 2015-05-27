using UnityEngine;
using System.Collections;

public class Colisao : MonoBehaviour
{
	
	private RaycastHit2D[] targets1;
	private RaycastHit2D[] targets2;
	private RaycastHit2D[] targets3;
	private RaycastHit2D[] targets4;
	private RaycastHit2D[] targets5;
	private RaycastHit2D[] targets6;
	private RaycastHit2D[] targets7;
	private RaycastHit2D[] targets8;

	public float attackDistance = 16;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		targets1 = Physics2D.RaycastAll((Vector2)transform.position, (Vector2)transform.position + new Vector2(attackDistance, 170) + Vector2.up, attackDistance, 1 << LayerMask.NameToLayer("Enemy"));
		Debug.DrawLine((Vector2)transform.position, (Vector2)transform.position + new Vector2(attackDistance, 170));
		Debug.DrawLine((Vector2)transform.position, (Vector2)transform.position + new Vector2(attackDistance, 0));
		Debug.DrawLine((Vector2)transform.position, (Vector2)transform.position + new Vector2(attackDistance, -170));
		Debug.DrawLine((Vector2)transform.position, (Vector2)transform.position + new Vector2(attackDistance, -15000));
		Debug.DrawLine((Vector2)transform.position, (Vector2)transform.position - new Vector2(attackDistance, 170));	
		Debug.DrawLine((Vector2)transform.position, (Vector2)transform.position - new Vector2(attackDistance, -170));
		Debug.DrawLine((Vector2)transform.position, (Vector2)transform.position - new Vector2(attackDistance, 0));
		Debug.DrawLine((Vector2)transform.position, (Vector2)transform.position + new Vector2(attackDistance, 15000));
	}
}
