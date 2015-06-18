using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour 
{

	//public static ScoreUI score;
    SceneMaster sceneMaster;
	public Text scoreTextUI;

	private float score = 0;

	float pontoTemp;

    void Start()
    {
        sceneMaster = GameObject.FindGameObjectWithTag("SceneMaster").GetComponent<SceneMaster>();
    }

	// Update is called once per frame
	void Update () 
	{
        score = sceneMaster.Score;

		if(pontoTemp < score)
		{
			pontoTemp += 1;
		}
		else
		{
			pontoTemp = score;
		}

		scoreTextUI.text = pontoTemp.ToString();
	}
}