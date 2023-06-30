using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChartboostSDK;
public class CallingAds : MonoBehaviour {
	Video obj = new Video ();
	//public GameObject rewardedfailed,rewardedsucceded;
	public static CallingAds instance;
	void Awake()
	{
		instance = this;
	}
	void Start()
	{
		//
	}

	public void ShowAdmobInter()
	{
		GoogleMobileAdsDemoScript.instance.ShowInterstitial();
		//GameObject.Find ("AdsPrefab").gameObject.GetComponent<GoogleMobileAdsDemoScript> ().ShowInterstitial ();
	}
	public void Showunityadd()
	{
		obj.ShowAd ();
	}
	public void bannerTL()
	{		
		GoogleMobileAdsDemoScript.instance.BannerTL();
		//GameObject.Find ("AdsPrefab").gameObject.GetComponent<GoogleMobileAdsDemoScript> ().BannerTL ();
	}
	public void bannerTR()
	{
		GoogleMobileAdsDemoScript.instance.BannerTR();
		//GameObject.Find ("AdsPrefab").gameObject.GetComponent<GoogleMobileAdsDemoScript> ().BannerTR ();
	}
	public void bannerTC()
	{
		GoogleMobileAdsDemoScript.instance.BannerTC();
		//GameObject.Find ("AdsPrefab").gameObject.GetComponent<GoogleMobileAdsDemoScript> ().BannerTC ();
	}
	public void bannerBC()
	{
		GoogleMobileAdsDemoScript.instance.BannerBC();
		//GameObject.Find ("AdsPrefab").gameObject.GetComponent<GoogleMobileAdsDemoScript> ().BannerBC ();
	}
	public void bannerBL()
	{
		GoogleMobileAdsDemoScript.instance.BannerBL();
		//GameObject.Find ("AdsPrefab").gameObject.GetComponent<GoogleMobileAdsDemoScript> ().BannerBL ();
	}
	public void bannerBR()
	{
		 GoogleMobileAdsDemoScript.instance.BannerBR();
		//GameObject.Find ("AdsPrefab").gameObject.GetComponent<GoogleMobileAdsDemoScript> ().BannerBR ();
	}
	public void ShowUnityRewardedAd()
	{
		obj.ShowRewardedAd ();
	}
	public void HideBaner()
	{
		GoogleMobileAdsDemoScript.instance.HideBanner ();
	}
	public void rewardedadd()
	{
		//GameObject.Find ("AdsPrefab").gameObject.GetComponent<GoogleMobileAdsDemoScript> ().ShowRewardBasedVideo();
		GoogleMobileAdsDemoScript.instance.ShowRewardBasedVideo();
	}
	public void chartboostadd()
	{
		if (Chartboost.hasInterstitial (CBLocation.Default)) {
			Chartboost.showInterstitial (CBLocation.Default);
		} else {
			Chartboost.cacheInterstitial (CBLocation.Default);
		}
	}

}
