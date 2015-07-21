using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SlowTime : MonoBehaviour 
{
	public string nome;

	public CompraPower power;

	public AudioClip audio;

	public Sprite sprite;

	public Image image;

	Sprite temp;

	public void Utiliza()
	{
		if(PlayerPrefs.GetInt(nome) >= 1)
		{
			temp = image.sprite;
			AudioSource.PlayClipAtPoint (audio, transform.position);
			Time.timeScale = 0.2f;
			image.sprite = sprite;
			PlayerPrefs.SetInt(nome, (PlayerPrefs.GetInt(nome) - 1));
			StartCoroutine("GO");
		}
		else
		{
			power.OpenBuy();
			Time.timeScale = 0;
		}
	}

	IEnumerator GO()
	{
		float start = Time.realtimeSinceStartup;
		while (Time.realtimeSinceStartup < start + 10)
		{
			yield return null;
		}
		image.sprite = temp;
		Time.timeScale = 1;
	}
}
