﻿using UnityEngine;
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
		FB.AppRequest(
			message: "Come play this great game!", 
			callback: LogCallback
			);
	}
	
	public void Share()
	{
		FB.Feed(                                                                                                                 
		        linkCaption: "Play Game Man",               
		        picture: "http://static.wixstatic.com/media/b5559f_f5c06b11d0c94058bf2eeaea5b239607.png_srz_p_600_356_75_22_0.50_1.20_0.00_png_srz",                                                     
		        linkName: "Play linkname",                                                                 
		        link: "http://apps.facebook.com/" + FB.AppId + "/?challenge_brag=" + (FB.IsLoggedIn ? FB.UserId : "guest")       
		        ); 
	}

	void LogCallback(FBResult response) 
	{
		Debug.Log(response.Text);
	}
}
