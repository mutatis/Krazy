using UnityEngine;
using System.Collections;

public class MudaCena : MonoBehaviour 
{
	public int x = 0;

	public void LoadScene(string level)
	{
		if(x == 0)
		{
			PlayerPrefs.SetString ("Loading", level);
			Application.LoadLevel ("Loading");
		}
		else
		{
			Application.LoadLevel ("Loading");
		}
	}
}
