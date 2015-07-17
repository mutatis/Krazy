using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScoreUI : MonoBehaviour 
{
    public List<GameObject> digits;
<<<<<<< HEAD
    public SceneMaster sceneMaster;
=======
    SceneMaster sceneMaster;
>>>>>>> 70a022da83cab5c448e565a9ea27f6eed1a1964e
    private int score = 0;

    void Start()
    {
<<<<<<< HEAD
		sceneMaster = GetComponent<SceneMaster> ();
=======
        sceneMaster = GetComponent<SceneMaster>();
>>>>>>> 70a022da83cab5c448e565a9ea27f6eed1a1964e
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
            {
                SetDigit(i, int.Parse(newScore[i].ToString()));
            }
                
        }
    }

    private string AddTrailingZeroes(int value, int expectedLength) 
    {
        string svalue = value.ToString();
        while (svalue.Length < expectedLength)
        {
            svalue = svalue.Insert(svalue.Length, "0");
        }
        return svalue;
    }

    
    void SetDigit(int index, int value)
    {
<<<<<<< HEAD
		digits [index].SendMessage ("SetValue", value);
=======
        digits[digit].SendMessage("SetValue", value);
>>>>>>> 70a022da83cab5c448e565a9ea27f6eed1a1964e
    }
}