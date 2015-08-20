using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using SIS;

public class ManagerBuyEnegia : MonoBehaviour
{	
	public GameObject compro;	

	public int preco;

	public void Buy()
	{
		if(/*DBManager.GetFunds("coins") >= preco*/ true)
		{
			//DBManager.IncreaseFunds("coins", (preco * -1));
			PlayerPrefs.SetInt("Energia", PlayerPrefs.GetInt("Energia") + 1);
			GameObject obj = Instantiate(compro) as GameObject;
			obj.GetComponent<BoaCompraManager>().nomePowerup = "Energia";
		}
	}
	
	public void Destroy()
	{
		Destroy (gameObject);
	}
}
