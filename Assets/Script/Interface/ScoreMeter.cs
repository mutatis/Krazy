using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreMeter : MonoBehaviour {
    private float score;
    public float maxScale;
    private float scoreGoal;
    public RectTransform liquidBody;
    public RectTransform tip;

	void Start()
	{
		print (transform.localPosition);
	}

	// Use this for initialization
    public void SetScore(float score)
    {
        this.score = score;
    }

    public void SetGoal(float scoreGoal)
    {
        this.scoreGoal = scoreGoal;
    }
	
	void Update () {
		if (score <= scoreGoal)
        	{
			var szd = liquidBody.sizeDelta;
	        	liquidBody.sizeDelta = new Vector2(szd.x, maxScale * (score / scoreGoal) + 1);
        		tip.position = new Vector3(0, (maxScale / 2) * (score / scoreGoal), 0);
		}
	}
}
