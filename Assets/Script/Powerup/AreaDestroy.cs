using UnityEngine;
using System.Collections;

public class AreaDestroy : MonoBehaviour 
{
	public string nome;

	public CompraPower power;

	public GameObject destruidor;
	
	public void Utiliza()
	{
		if(PlayerPrefs.GetInt(nome) >= 1)
		{
			PlayerPrefs.SetInt(nome, (PlayerPrefs.GetInt(nome) - 1));
			Instantiate(destruidor);
		}
		else
		{
			power.OpenBuy();
			Time.timeScale = 0;
		}
	}
}
