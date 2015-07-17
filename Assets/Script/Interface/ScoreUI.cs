using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScoreUI : MonoBehaviour 
{
    public List<GameObject> digits;
    public SceneMaster sceneMaster;
    private int score = 0;

    void Start()
    {
		sceneMaster = GetComponent<SceneMaster> ();
    }

    void Update()
    {
        if (score != sceneMaster.Score)
        {
            OnChangeScore(score, sceneMaster.Score);
            score = sceneMaster.Score;
        }
    }

    void OnChangeScore(int _oldScore, int _newScore)
    {
        var scoreboardLength = digits.Count;
        string oldScore = AddTrailingZeroes(_oldScore, scoreboardLength);
        string newScore = AddTrailingZeroes(_newScore, scoreboardLength);

        for (int i = 0; i < scoreboardLength; i++)
        {
            if (oldScore[i] != newScore[i])
                SetDigit(i, newScore[i]);
        }
    }

    private string AddTrailingZeroes(int value, int expectedLength) 
    {
        string svalue = value.ToString();
        while (svalue.Length < expectedLength)
        {
            svalue = svalue.Insert(0, "0");
        }
        return svalue;
    }

    
    void SetDigit(int index, int value)
    {
		digits [index].SendMessage ("SetValue", value);
    }
}