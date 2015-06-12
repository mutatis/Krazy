using UnityEngine;
using System.Collections;
using UnityEngine.Cloud.Analytics;

public class UnityAnalyticsIntegration : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
		const string projectId = "d52a63c7-7323-4b2e-abf2-03c17bbe6819";
		UnityAnalytics.StartSDK (projectId);
		
	}
	
}