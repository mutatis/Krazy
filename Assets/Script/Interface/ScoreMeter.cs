using UnityEngine;
using System.Collections;

public class ScoreMeter : MonoBehaviour {
    private float score;
    public float maxScale;
    private float scoreGoal;
    public GameObject liquidBody;
    public GameObject tip;
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
        liquidBody.transform.localScale = new Vector3(1, maxScale * (score / scoreGoal) + 1, 1);
        tip.transform.localPosition = new Vector3(0, (maxScale / 2) * (score / scoreGoal), 0);
	}
}
