using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextEnd : MonoBehaviour 
{

	public Text text;

	// Use this for initialization
	void Start () 
	{
		if(Score.score.ponto < Manager.minPonto)
		{
			text.text = ("Voce fez " + Score.score.ponto.ToString() + " mas precisava de " + Manager.minPonto);
		}
		else
		{
			text.text = ("Voce fez " + Score.score.ponto.ToString() + " voce passou mandou bem garoto");
		}
	}
}
