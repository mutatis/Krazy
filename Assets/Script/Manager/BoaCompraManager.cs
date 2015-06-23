using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoaCompraManager : MonoBehaviour 
{
	public Text text;

	public string texto1;
	[HideInInspector]
	public string nomePowerup;
	public string texto2;

	void Start()
	{
		text.text = texto1 + nomePowerup + texto2;
	}

	public void Destroy()
	{
		Destroy (gameObject);
	}
}
