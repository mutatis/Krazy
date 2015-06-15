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
	
	public void Share()
	{
		if(FB.IsLoggedIn)
		{
			FB.Feed(                                                                                                                 
			        linkCaption: "Play Game Man",               
			        picture: "http://static.wixstatic.com/media/b5559f_f5c06b11d0c94058bf2eeaea5b239607.png_srz_p_600_356_75_22_0.50_1.20_0.00_png_srz",                                                     
			        linkName: "Play linkname",                                                                 
			        link: "http://apps.facebook.com/" + FB.AppId + "/?challenge_brag=" + (FB.IsLoggedIn ? FB.UserId : "guest")       
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
