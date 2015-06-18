using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CompraPower : MonoBehaviour 
{
	public GameObject compraPower;

	public Sprite icone;

	public string titulo;
	public string descricao;
	public int preco;

	public void OpenBuy()
	{
		GameObject obj = Instantiate (compraPower) as GameObject;
		obj.GetComponent<ManagerBuyPower> ().titulo = titulo;
		obj.GetComponent<ManagerBuyPower> ().descricao = descricao;
		obj.GetComponent<ManagerBuyPower> ().preco = preco;
		obj.GetComponent<ManagerBuyPower> ().icone = icone;
	}
}
