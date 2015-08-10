using UnityEngine;
using System.Collections;

public class SFC : MonoBehaviour 
{

    public GameObject[] obj;

    void Start()
    {
        obj[Random.Range(0, obj.Length)].SetActive(true);
    }

    public void CVS()
    {
#if UNITY_ANDROID
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.DagonStudios.Cthulhu");
#endif
#if UNITY_IOS
		Application.OpenURL("https://itunes.apple.com/us/app/cthulhu-v-santa-claus-war/id957398997?l=pt&ls=1&mt=8");
#endif
    }

    public void SFCG ()
	{
#if UNITY_ANDROID
		Application.OpenURL("https://play.google.com/store/apps/details?id=com.DagonStudios.SuperFlappyCthulhuFinal");
#endif
#if UNITY_IOS
		Application.OpenURL("https://itunes.apple.com/us/app/super-flappy-cthulhu/id966966676?l=pt&ls=1&mt=8");
#endif
	}
}
