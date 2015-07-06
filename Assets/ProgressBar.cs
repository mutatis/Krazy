using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{

	public Slider sli;

	SceneMaster sceneMaster;

	float maxValue;
	float value;

	// Use this for initialization
	void Start ()
	{
		sceneMaster = GameObject.FindGameObjectWithTag ("SceneMaster").GetComponent<SceneMaster> ();
		maxValue = sceneMaster.meta3Estrelas;
		sli.maxValue = maxValue;
		sli.value = maxValue;
	}
	
	// Update is called once per frame
	void Update () 
	{
		sli.value = maxValue - sceneMaster.Score;
	}
}
