using System;
using UnityEngine;
using UnityEngine.UI;
public class DicasUI : MonoBehaviour {
    [Multiline]
    public string[] textoDica;
    public float readingSpeed;
    public Text dicasText;
    public AudioClip charSound;
    private int painel = 0;
    private float charCount;
    private int lastCount;
    private float realTime;
    void Start () {
        realTime = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
        var deltaTime = Time.realtimeSinceStartup - realTime;
        realTime = Time.realtimeSinceStartup;
        //print(deltaTime);
	    if(Input.GetMouseButtonDown(0))
        {
            if (painel >= textoDica.Length)
            {
                //gameObject.GetComponent<Animator>().SetTrigger("Close");
                GameObject.FindGameObjectWithTag("SceneMaster").GetComponent<SceneMaster>().BeginLevel();
                gameObject.SetActive(false);
                return;
            }
            
            if (charCount < textoDica[painel].Length)
            {
                charCount = textoDica[painel].Length;
            }
            else
            {
                if (painel < textoDica.Length)
                    painel++;
            }   
        }
        

        var count = (int)charCount;
        if (count - lastCount >= 1)
        {
            PlaySound();
            lastCount = count;
        }

        if (painel >= textoDica.Length)
            return;

        charCount = Mathf.Clamp(charCount + (readingSpeed * deltaTime), .0f, textoDica[painel].Length);
        //readingSpeed += deltaTime * 2;
        dicasText.text = textoDica[painel].Substring(0, (int)charCount);
    }

    private void PlaySound()
    {
        Time.timeScale = 1;
        AudioSource.PlayClipAtPoint(charSound, transform.position, 1.0f);
        Time.timeScale = 0;
    }
}
