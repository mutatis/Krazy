using UnityEngine;
using System.Collections;

public class SFC : MonoBehaviour 
{
	public void Link ()
	{
#if UNITY_ANDROID
		Application.OpenURL("https://play.google.com/store/apps/details?id=com.DagonStudios.SuperFlappyCthulhuFinal");
#endif
#if UNITY_IOS
		Application.OpenURL("https://itunes.apple.com/us/app/super-flappy-cthulhu/id966966676?l=pt&ls=1&mt=8");
#endif
	}
}
