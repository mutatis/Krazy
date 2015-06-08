using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour 
{

	public static Score score;

	public Text text;

	[HideInInspector]
	public float ponto;

	float pontoTemp;

	void Awake()
	{
		score = this;
	}

	public void Ponto(float soma)
	{
		ponto += soma;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(pontoTemp < ponto)
		{
			pontoTemp += 1;
		}
		else
		{
			pontoTemp = ponto;
		}
		text.text = pontoTemp.ToString ();
	}
}
