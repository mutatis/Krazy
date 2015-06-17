using UnityEngine;
using System.Collections;

public class MudaCena : MonoBehaviour 
{
	public void LoadScene(string level)
	{
		PlayerPrefs.SetString ("Loading", level);
		Application.LoadLevel ("Loading");
	}
}
