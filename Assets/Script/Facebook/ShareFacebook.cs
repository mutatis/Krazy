using UnityEngine;
using System.Collections;

public class ShareFacebook : MonoBehaviour {
    public string linkCaption;
    public string picture;
    public string linkName;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Share()
	{
		if(FB.IsLoggedIn)
		{
			FB.Feed(                                                                                                                 
			        linkCaption: linkCaption,               
			        picture: picture,                                                     
			        linkName: linkName,                                                                 
			        link: "http://www.dagonstudios.com/"       
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
}
