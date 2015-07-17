using UnityEngine;
using System.Collections;

public class SlowTime : MonoBehaviour 
{
	public string nome;

	public CompraPower power;

	public AudioClip audio;

	public void Utiliza()
	{
		if(PlayerPrefs.GetInt(nome) >= 1)
		{
			AudioSource.PlayClipAtPoint (audio, transform.position);
			Time.timeScale = 0.2f;
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
		Time.timeScale = 1;
	}
}
