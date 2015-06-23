using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextDicas : MonoBehaviour 
{
	public SceneMaster sceneMaster;

	public Text text;

	// Use this for initialization
	void Start () 
	{
		text.text = "Voce precisa fazer no minimo " + sceneMaster.meta1Estrela;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
