using UnityEngine;
using System.Collections;

public class Colisao : MonoBehaviour
{
	public static Colisao colision;

	public RaycastHit2D[] targets1;
	public RaycastHit2D[] targets2;
	public RaycastHit2D[] targets3;
	public RaycastHit2D[] targets4;

	//public float attackDistance = 16;
	public float direction;

	[HideInInspector]
	public int mult1 = 1;
	public int mult2 = 1;
	public int mult3 = 1;
	public int mult4 = 1;

	void Awake()
	{
		colision = this;
	}
	
	void Start () 
	{
	
	}

	void Update ()
	{

	}

	public void Attack(float attackDistance, int tipo)
	{
		if(tipo == 1)
		{
			targets1 = Physics2D.RaycastAll((Vector2)transform.position, Vector2.right, attackDistance * mult1, 1 << LayerMask.NameToLayer("UI"));
		}
		else if(tipo == 2)
		{
			targets2 = Physics2D.RaycastAll((Vector2)transform.position, Vector2.right * -1, attackDistance * mult2, 1 << LayerMask.NameToLayer("UI"));
		}
		else if(tipo == 3)
		{
			targets3 = Physics2D.RaycastAll((Vector2)transform.position, Vector2.up, attackDistance * mult3, 1 << LayerMask.NameToLayer("UI"));
		}
		else if(tipo == 4)
		{
			targets4 = Physics2D.RaycastAll((Vector2)transform.position, Vector2.up * -1, attackDistance * mult4, 1 << LayerMask.NameToLayer("UI"));	
		}
		else
		{
			targets1 = Physics2D.RaycastAll((Vector2)transform.position, Vector2.right, attackDistance * mult1, 1 << LayerMask.NameToLayer("UI"));
			targets2 = Physics2D.RaycastAll((Vector2)transform.position, Vector2.right * -1, attackDistance * mult2, 1 << LayerMask.NameToLayer("UI"));
			targets3 = Physics2D.RaycastAll((Vector2)transform.position, Vector2.up, attackDistance * mult3, 1 << LayerMask.NameToLayer("UI"));
			targets4 = Physics2D.RaycastAll((Vector2)transform.position, Vector2.up * -1, attackDistance * mult4, 1 << LayerMask.NameToLayer("UI"));
		}
		
		if(targets1.Length > targets2.Length && targets1.Length > targets3.Length && targets1.Length > targets4.Length)
		{
			AttackAgain.attackA.Attack(1, gameObject);
		}
		else if(targets2.Length > targets1.Length && targets2.Length > targets3.Length && targets2.Length > targets4.Length)
		{
			AttackAgain.attackA.Attack(2, gameObject);
		}
		else if(targets3.Length > targets1.Length && targets3.Length > targets2.Length && targets3.Length > targets4.Length)
		{
			AttackAgain.attackA.Attack(3, gameObject);
		}
		else if(targets4.Length > targets1.Length && targets4.Length > targets2.Length && targets4.Length > targets3.Length)
		{
			AttackAgain.attackA.Attack(4, gameObject);
		}
		else
		{
//			print("5");
		}

//		print (targets1.Length + " " + targets2.Length + " " + targets3.Length + " " + targets4.Length + " ");
	}

	void Kill(int tipo)
	{
		if(tipo == 1)
		{
			for(int i = 0; i < targets1.Length; i++)
			{
				Destroy(targets1[i].collider.gameObject);
			}
		}
		if(tipo == 2)
		{
			for(int i = 0; i < targets2.Length; i++)
			{
				Destroy(targets2[i].collider.gameObject);
			}
		}
		if(tipo == 3)
		{
			for(int i = 0; i < targets3.Length; i++)
			{
				Destroy(targets3[i].collider.gameObject);
			}
		}
		if(tipo == 4)
		{
			for(int i = 0; i < targets4.Length; i++)
			{
				Destroy(targets4[i].collider.gameObject);
			}
		}
	}

	/*void AttackAgain(int tipo)
	{
		if(tipo == 1 && targets1.Length >= 3)
		{
			Kill(1);
		}

		if(tipo == 2 && targets2.Length >= 3)
		{
			Kill(2);
		}

		if(tipo == 3 && targets3.Length >= 3)
		{
			Kill(3);
		}

		if(tipo == 4 && targets1.Length >= 3)
		{
			Kill(4);
		}
	}
*/


		/*if(targets1.Length >= 2)
		{
			mult1 = targets1.Length;
			AttackAgain(1);
		}
		if(targets2.Length >= 2)
		{
			mult2 = targets2.Length;
			AttackAgain(2);
		}
		if(targets3.Length >= 2)
		{
			mult3 = targets3.Length;
			AttackAgain(3);
		}
		if(targets4.Length >= 2)
		{
			mult4 = targets4.Length;
			AttackAgain(4);
		}*/
}