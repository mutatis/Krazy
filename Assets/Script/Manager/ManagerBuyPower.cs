using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SIS;

public class ManagerBuyPower : MonoBehaviour 
{
	public GameObject compro;	

	public Text textTitulo;
	public Text textDescricao;
	public Text textPreco;

	public Image imgIcone;

	public Sprite icone;

	public string titulo;
	public string descricao;
	public int preco;

	// Use this for initialization
	void Start () 
	{
		textTitulo.text = titulo;
		textDescricao.text = descricao;
		textPreco.text = preco.ToString();
		imgIcone.sprite = icone;
	}

	public void Buy()
	{
		if(DBManager.GetFunds("coins") >= preco)
		{
			DBManager.IncreaseFunds("coins", (preco * -1));
			PlayerPrefs.SetInt(titulo, PlayerPrefs.GetInt(titulo) + 1);
			Instantiate(compro);
		}
	}
	
	public void Destroy()
	{
		if(Time.timeScale == 0)
		{
			Time.timeScale = 1;
		}
		Destroy (gameObject);
	}
}
