using UnityEngine;
using System.Collections;
using ChartboostSDK;
public class chacheCalls : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Chartboost.cacheInterstitial(CBLocation.MainMenu);
		Chartboost.cacheInterstitial(CBLocation.GameLoopEnd);
		Chartboost.cacheInterstitial(CBLocation.Static);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
