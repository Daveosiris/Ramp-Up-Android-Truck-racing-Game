using UnityEngine;
using System.Collections;
using ChartboostSDK;

public class ChartBoostListeners : MonoBehaviour {
	public string Tag="Cb Pangay";
	void OnEnable() {
		// Listen to all impression-related events
		Chartboost.didFailToLoadInterstitial += didFailToLoadInterstitial;
		Chartboost.didDismissInterstitial += didDismissInterstitial;
		Chartboost.didCloseInterstitial += didCloseInterstitial;
		Chartboost.didClickInterstitial += didClickInterstitial;
		Chartboost.didCacheInterstitial += didCacheInterstitial;
		Chartboost.shouldDisplayInterstitial += shouldDisplayInterstitial;
		Chartboost.didDisplayInterstitial += didDisplayInterstitial;
		Chartboost.didFailToLoadMoreApps += didFailToLoadMoreApps;
		Chartboost.didDismissMoreApps += didDismissMoreApps;
		Chartboost.didCloseMoreApps += didCloseMoreApps;
		Chartboost.didClickMoreApps += didClickMoreApps;
		Chartboost.didCacheMoreApps += didCacheMoreApps;
		Chartboost.shouldDisplayMoreApps += shouldDisplayMoreApps;
		Chartboost.didDisplayMoreApps += didDisplayMoreApps;
//		Chartboost.didFailToRecordClick += didFailToRecordClick;
		Chartboost.didFailToLoadRewardedVideo += didFailToLoadRewardedVideo;
		Chartboost.didDismissRewardedVideo += didDismissRewardedVideo;
		Chartboost.didCloseRewardedVideo += didCloseRewardedVideo;
		Chartboost.didClickRewardedVideo += didClickRewardedVideo;
		Chartboost.didCacheRewardedVideo += didCacheRewardedVideo;
		Chartboost.shouldDisplayRewardedVideo += shouldDisplayRewardedVideo;
		Chartboost.didCompleteRewardedVideo += didCompleteRewardedVideo;
		Chartboost.didDisplayRewardedVideo += didDisplayRewardedVideo;
		Chartboost.didCacheInPlay += didCacheInPlay;
		Chartboost.didFailToLoadInPlay += didFailToLoadInPlay;
		Chartboost.didPauseClickForConfirmation += didPauseClickForConfirmation;
		#if UNITY_IPHONE
		Chartboost.didCompleteAppStoreSheetFlow += didCompleteAppStoreSheetFlow;
		#endif
	}

	void OnDisable() {
		// Remove event handlers
		Chartboost.didFailToLoadInterstitial -= didFailToLoadInterstitial;
		Chartboost.didDismissInterstitial -= didDismissInterstitial;
		Chartboost.didCloseInterstitial -= didCloseInterstitial;
		Chartboost.didClickInterstitial -= didClickInterstitial;
		Chartboost.didCacheInterstitial -= didCacheInterstitial;
		Chartboost.shouldDisplayInterstitial -= shouldDisplayInterstitial;
		Chartboost.didDisplayInterstitial -= didDisplayInterstitial;
		Chartboost.didFailToLoadMoreApps -= didFailToLoadMoreApps;
		Chartboost.didDismissMoreApps -= didDismissMoreApps;
		Chartboost.didCloseMoreApps -= didCloseMoreApps;
		Chartboost.didClickMoreApps -= didClickMoreApps;
		Chartboost.didCacheMoreApps -= didCacheMoreApps;
		Chartboost.shouldDisplayMoreApps -= shouldDisplayMoreApps;
		Chartboost.didDisplayMoreApps -= didDisplayMoreApps;
				//
//				Chartboost.didFailToRecordClick -= didFailToRecordClick;
		Chartboost.didFailToLoadRewardedVideo -= didFailToLoadRewardedVideo;
		Chartboost.didDismissRewardedVideo -= didDismissRewardedVideo;
		Chartboost.didCloseRewardedVideo -= didCloseRewardedVideo;
		Chartboost.didClickRewardedVideo -= didClickRewardedVideo;
		Chartboost.didCacheRewardedVideo -= didCacheRewardedVideo;
		Chartboost.shouldDisplayRewardedVideo -= shouldDisplayRewardedVideo;
		Chartboost.didCompleteRewardedVideo -= didCompleteRewardedVideo;
		Chartboost.didDisplayRewardedVideo -= didDisplayRewardedVideo;
		Chartboost.didCacheInPlay -= didCacheInPlay;
		Chartboost.didFailToLoadInPlay -= didFailToLoadInPlay;
		Chartboost.didPauseClickForConfirmation -= didPauseClickForConfirmation;
		#if UNITY_IPHONE
		Chartboost.didCompleteAppStoreSheetFlow -= didCompleteAppStoreSheetFlow;
		#endif
	}
	
	
	
	void didFailToLoadInterstitial(CBLocation location, CBImpressionError error) {
		Debug.Log(string.Format(Tag+"didFailToLoadInterstitial: {0} at location {1}", error, location));
	}
	
	void didDismissInterstitial(CBLocation location) {
		//AppController.chartBoostShow = false;
		Debug.Log(Tag+"didDismissInterstitial: " + location);
	}
	
	void didCloseInterstitial(CBLocation location) {
		//AppController.chartBoostShow = false;
		Debug.Log(Tag+"didCloseInterstitial: " + location);
		GameObject.Find("AdMob").GetComponent<GoogleMobileAdsDemoScript>().RequestBanner();
		//set active false

		//banner show
	}
	
	void didClickInterstitial(CBLocation location) {
		Debug.Log(Tag+"didClickInterstitial: " + location);
		GameObject.Find("AdMob").GetComponent<GoogleMobileAdsDemoScript>().RequestBanner();

		//set active false
		//banner show
	}
	
	void didCacheInterstitial(CBLocation location) {
		Debug.Log(Tag+"didCacheInterstitial: " + location);
	}
	
	bool shouldDisplayInterstitial(CBLocation location) {
		Debug.Log(Tag+"shouldDisplayInterstitial: " + location);
		return true;
	}
	
	void didDisplayInterstitial(CBLocation location){
		//AppController.chartBoostShow = true;
		Debug.Log(Tag+"didDisplayInterstitial: " + location);
		GameObject.Find("AdMob").GetComponent<GoogleMobileAdsDemoScript>().HideBanner();
		//set active true
		//banner hide
	}
	
	void didFailToLoadMoreApps(CBLocation location, CBImpressionError error) {
		Debug.Log(string.Format("didFailToLoadMoreApps: {0} at location: {1}", error, location));
	}
	
	void didDismissMoreApps(CBLocation location) {
		Debug.Log(string.Format("didDismissMoreApps at location: {0}", location));
	}
	
	void didCloseMoreApps(CBLocation location) {
		Debug.Log(string.Format("didCloseMoreApps at location: {0}", location));
	}
	
	void didClickMoreApps(CBLocation location) {
		Debug.Log(string.Format("didClickMoreApps at location: {0}", location));
	}
	
	void didCacheMoreApps(CBLocation location) {
		Debug.Log(string.Format("didCacheMoreApps at location: {0}", location));
	}
	
	bool shouldDisplayMoreApps(CBLocation location) {
		Debug.Log(string.Format("shouldDisplayMoreApps at location: {0}", location));
		return true;
	}
	
	void didDisplayMoreApps(CBLocation location){
		Debug.Log("didDisplayMoreApps: " + location);
	}
	
	void didFailToRecordClick(CBLocation location, CBImpressionError error) {
		Debug.Log(string.Format("didFailToRecordClick: {0} at location: {1}", error, location));
	}
	
	void didFailToLoadRewardedVideo(CBLocation location, CBImpressionError error) {
		Debug.Log(string.Format("didFailToLoadRewardedVideo: {0} at location {1}", error, location));
	}
	
	void didDismissRewardedVideo(CBLocation location) {
		Debug.Log("didDismissRewardedVideo: " + location);
	}
	
	void didCloseRewardedVideo(CBLocation location) {
		Debug.Log("didCloseRewardedVideo: " + location);
	}
	
	void didClickRewardedVideo(CBLocation location) {
		Debug.Log("didClickRewardedVideo: " + location);
	}
	
	void didCacheRewardedVideo(CBLocation location) {
		Debug.Log("didCacheRewardedVideo: " + location);
	}
	
	bool shouldDisplayRewardedVideo(CBLocation location) {
		Debug.Log("shouldDisplayRewardedVideo: " + location);
		return true;
	}
	
	void didCompleteRewardedVideo(CBLocation location, int reward) {
		Debug.Log(string.Format("didCompleteRewardedVideo: reward {0} at location {1}", reward, location));
	}
	
	void didDisplayRewardedVideo(CBLocation location){
		Debug.Log("didDisplayRewardedVideo: " + location);
	}
	
	void didCacheInPlay(CBLocation location) {
		Debug.Log("didCacheInPlay called: "+location);
	}
	
	void didFailToLoadInPlay(CBLocation location, CBImpressionError error) {
		Debug.Log(string.Format("didFailToLoadInPlay: {0} at location: {1}", error, location));
	}
	
	void didPauseClickForConfirmation() {
		Debug.Log("didPauseClickForConfirmation called");
	}
	
	#if UNITY_IPHONE
	void didCompleteAppStoreSheetFlow() {
		Debug.Log("didCompleteAppStoreSheetFlow");
	}
	#endif

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
