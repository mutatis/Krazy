using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreMeter : MonoBehaviour
{
    private float score;
    public float maxHeight;
	private float scoreFloor;
    private float scoreGoal;
    private RectTransform rectTransform;
    private Vector2 initialPosition;

    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        initialPosition = rectTransform.localPosition;
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

	public void SetFloor(float scoreFloor) 
	{
		this.scoreFloor = scoreFloor;
	}

    void Update()
    {
        if (score >= scoreFloor && score <= scoreGoal)
        {
            rectTransform.localPosition = Vector2.Lerp(
				rectTransform.localPosition, 
				(initialPosition + new Vector2(0, maxHeight * ((score - scoreFloor) / (scoreGoal - scoreFloor)))), 
				Time.deltaTime);
        }
    }
}
