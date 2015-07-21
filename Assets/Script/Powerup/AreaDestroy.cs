using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AreaDestroy : MonoBehaviour 
{
	public string nome;

	public CompraPower power;

	public GameObject destruidor;
	
	public Sprite sprite;
	
	public Image image;
	
	Sprite temp;
	
	public void Utiliza()
	{
		if(PlayerPrefs.GetInt(nome) >= 1)
		{
			PlayerPrefs.SetInt(nome, (PlayerPrefs.GetInt(nome) - 1));
			temp = image.sprite;
			image.sprite = sprite;
			Instantiate(destruidor);
		}
		else
		{
			power.OpenBuy();
			Time.timeScale = 0;
		}
	}

	public void Volta()
	{
		image.sprite = temp;
	}
}
