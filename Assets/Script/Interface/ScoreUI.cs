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
    float increaseSpeed = 1;

    void Start()
    {
        sceneMaster = GameObject.FindGameObjectWithTag("SceneMaster").GetComponent<SceneMaster>();
    }

	// Update is called once per frame
	void Update () 
	{
        score = sceneMaster.Score;
        increaseSpeed += 5 * Time.deltaTime;
		if(pontoTemp < score)
		{
			pontoTemp = Mathf.Clamp(pontoTemp + increaseSpeed, 0, score);
		}
		else
		{
			pontoTemp = score;
		}

		scoreTextUI.text = pontoTemp.ToString();
	}
}