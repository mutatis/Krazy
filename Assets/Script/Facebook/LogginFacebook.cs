using UnityEngine;
using System.Collections;

public class LogginFacebook : MonoBehaviour 
{

	void Awake()
	{
		FB.Init (FBLogin);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void Login()
	{
		FBLogin ();
	}

	private void FBLogin() {
		FB.Login("user_about_me, user_relationships, user_birthday, user_location", FBLoginCallback);
	}
	
	private void FBLoginCallback(FBResult result) {
		if(FB.IsLoggedIn) {
			Debug.Log ("Logo");
		} else {
			Debug.Log ("FBLoginCallback: User canceled login");
		}
	}
}
