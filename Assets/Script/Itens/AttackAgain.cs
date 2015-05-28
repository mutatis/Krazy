using UnityEngine;
using System.Collections;

public class AttackAgain : MonoBehaviour 
{
	public static AttackAgain attackA;
	float distanceAttack = 1;

	void Awake()
	{
		attackA = this;
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Attack(int tipo, GameObject obj)
	{
		if(tipo == 1)
		{
			distanceAttack += obj.GetComponent<Colisao>().targets1.Length;
			obj.GetComponent<Colisao>().Attack(distanceAttack, tipo);
		}
		else if(tipo == 2)
		{
			distanceAttack += obj.GetComponent<Colisao>().targets2.Length;
			obj.GetComponent<Colisao>().Attack(distanceAttack, tipo);
		}
		else if(tipo == 3)
		{
			distanceAttack += obj.GetComponent<Colisao>().targets3.Length;
			obj.GetComponent<Colisao>().Attack(distanceAttack, tipo);
		}
		else if(tipo == 4)
		{
			distanceAttack += obj.GetComponent<Colisao>().targets4.Length;
			obj.GetComponent<Colisao>().Attack(distanceAttack, tipo);
		}
	}
}
