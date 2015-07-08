using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {
    private Text textUI;
    private bool active;
    private float internalTime;
    private float timeStart;

	// Use this for initialization
	void Start () {
        textUI = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (active)
        {
            internalTime -= Time.deltaTime;
            textUI.text = GetFormattedTime(internalTime);
        }
        
	}

    public void StartTimer()
    {
        active = true;
    }

    public void StopTimer()
    {
        active = false;
    }

    public void SetTimer(float time)
    {
        internalTime = time;
    }

    private string GetFormattedTime(float time)
    {
        var minutos = (int)(time / 60);
        var segundos = (int)time % 60;
        return minutos + ":" + (segundos >= 10 ? segundos.ToString() : "0" + segundos);
    }
}
