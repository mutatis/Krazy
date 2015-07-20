using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreMeter : MonoBehaviour
{
    private float score;
    public float maxHeight;
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

    void Update()
    {
        if (score <= scoreGoal)
        {
            rectTransform.localPosition = Vector2.Lerp(rectTransform.localPosition, (initialPosition + new Vector2(0, maxHeight * (score / scoreGoal))), Time.deltaTime);
        }
    }
}
