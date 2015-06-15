using UnityEngine;
using System.Collections;
using UnityEngine;
using Facebook.MiniJSON;

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

	private void onChallengeClicked()                                                                                              
	{ 
		FB.AppRequest(
			to: null,
			filters : "",
			excludeIds : null,
			message: "Friend Smash is smashing! Check it out.",
			title: "Play Friend Smash with me!",
			callback:appRequestCallback
			);                                                                                                                
		
	}                                                                                                                              
	private void appRequestCallback (FBResult result)                                                                              
	{                                                                                                                              
		Util.Log("appRequestCallback");                                                                                         
		if (result != null)                                                                                                        
		{                                                                                                                          
			var responseObject = Json.Deserialize(result.Text) as Dictionary<string, object>;                                      
			object obj = 0;                                                                                                        
			if (responseObject.TryGetValue ("cancelled", out obj))                                                                 
			{                                                                                                                      
				Util.Log("Request cancelled");                                                                                  
			}                                                                                                                      
			else if (responseObject.TryGetValue ("request", out obj))                                                              
			{                
				AddPopupMessage("Request Sent", ChallengeDisplayTime);
				Util.Log("Request sent");                                                                                       
			}                                                                                                                      
		}                                                                                                                          
	}
}
