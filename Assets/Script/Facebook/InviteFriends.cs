using UnityEngine;
using System.Collections;

public class InviteFriends : MonoBehaviour 
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Invite()
	{
		if(FB.IsLoggedIn)
		{
			FB.AppRequest(
				message: "Come play this great game!", 
				callback: LogCallback
				);
		}
		else
		{
			FB.Login("user_about_me, user_relationships, user_birthday, user_location", FBLoginCallback);
		}
	}

	private void FBLoginCallback(FBResult result) {
		if(FB.IsLoggedIn) {
			Debug.Log ("Logo");
		} else {
			Debug.Log ("FBLoginCallback: User canceled login");
		}
	}

	void LogCallback(FBResult response) 
	{
		Debug.Log(response.Text);
	}
}
