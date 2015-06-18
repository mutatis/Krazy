using UnityEngine;
using System.Collections;

public class PowerUpManager : MonoBehaviour 
{
	public string nome;
	public CompraPower power;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Utiliza()
	{
		if(PlayerPrefs.GetInt(nome) >= 1)
		{
			//usa power up
		}
		else
		{
			power.OpenBuy();
			Time.timeScale = 0;
		}
	}
}
