using UnityEngine;
using System.Collections;

public class PowerUpManager : MonoBehaviour 
{
	public string nome;
	public GameObject shopPowerUp;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Utiliza()
	{
		Time.timeScale = 0;
		if(PlayerPrefs.GetInt(nome) == 1)
		{
			//usa power up
		}
		else
		{
			shopPowerUp.SetActive(true);
		}
	}
}
