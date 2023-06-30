using System;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;



// Example script showing how to invoke the Google Mobile Ads Unity plugin.
public class GoogleMobileAdsDemoScript : MonoBehaviour
{

    public string banner_ID, inter_ID,Reward_Video_ID;
    public string bannerIOS_ID, interIOS_ID;
    private BannerView bannerView;
    private InterstitialAd interstitial;
    private RewardBasedVideoAd rewardBasedVideo;
    private static string outputMessage = "";
	public static GoogleMobileAdsDemoScript instance;
    public static string OutputMessage
    {
        set { outputMessage = value; }
    }

	void Awake()
	{
		instance = this;
	}
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        // Get singleton reward based video ad reference.
        this.rewardBasedVideo = RewardBasedVideoAd.Instance;
        // RewardBasedVideoAd is a singleton, so handlers should only be registered once.
        rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
        rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
        rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
        rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;
		this.RequestRewardBasedVideo ();
       // RequestBanner();
        RequestInterstitial();
    }

    
	public void RequestBanner()
    {
        #if UNITY_EDITOR
            string adUnitId = "unused";
        #elif UNITY_ANDROID
            string adUnitId = banner_ID;
#elif UNITY_IOS
            string adUnitId = bannerIOS_ID;
#else
            string adUnitId = "unexpected_platform";
#endif

            // Create a 320x50 banner at the top of the screen.
		bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);
        // Register for ad events.
        bannerView.OnAdLoaded += HandleAdLoaded;
        bannerView.OnAdFailedToLoad += HandleAdFailedToLoad;
        bannerView.OnAdLoaded += HandleAdOpened;
        bannerView.OnAdClosed += HandleAdClosed;
        bannerView.OnAdLeavingApplication += HandleAdLeftApplication;
        // Load a banner ad.
        bannerView.LoadAd(createAdRequest());
    }
		public void BannerTL()
	{
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = banner_ID;
		#elif UNITY_IOS
		string adUnitId = bannerIOS_ID;
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create a 320x50 banner at the top of the screen.
		bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.TopLeft);
		// Register for ad events.
		bannerView.OnAdLoaded += HandleAdLoaded;
		bannerView.OnAdFailedToLoad += HandleAdFailedToLoad;
		bannerView.OnAdLoaded += HandleAdOpened;
		bannerView.OnAdClosed += HandleAdClosed;
		bannerView.OnAdLeavingApplication += HandleAdLeftApplication;
		// Load a banner ad.
		bannerView.LoadAd(createAdRequest());
	}
		public void BannerTR()
		{
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = banner_ID;
		#elif UNITY_IOS
		string adUnitId = bannerIOS_ID;
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create a 320x50 banner at the top of the screen.
		bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.TopRight);
		// Register for ad events.
		bannerView.OnAdLoaded += HandleAdLoaded;
		bannerView.OnAdFailedToLoad += HandleAdFailedToLoad;
		bannerView.OnAdLoaded += HandleAdOpened;
		bannerView.OnAdClosed += HandleAdClosed;
		bannerView.OnAdLeavingApplication += HandleAdLeftApplication;
		// Load a banner ad.
		bannerView.LoadAd(createAdRequest());
		}
		public void BannerTC()
		{
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = banner_ID;
		#elif UNITY_IOS
		string adUnitId = bannerIOS_ID;
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create a 320x50 banner at the top of the screen.
		bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
		// Register for ad events.
		bannerView.OnAdLoaded += HandleAdLoaded;
		bannerView.OnAdFailedToLoad += HandleAdFailedToLoad;
		bannerView.OnAdLoaded += HandleAdOpened;
		bannerView.OnAdClosed += HandleAdClosed;
		bannerView.OnAdLeavingApplication += HandleAdLeftApplication;
		// Load a banner ad.
		bannerView.LoadAd(createAdRequest());
		}
		public void BannerBC()
		{
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = banner_ID;
		#elif UNITY_IOS
		string adUnitId = bannerIOS_ID;
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create a 320x50 banner at the top of the screen.
		bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
		// Register for ad events.
		bannerView.OnAdLoaded += HandleAdLoaded;
		bannerView.OnAdFailedToLoad += HandleAdFailedToLoad;
		bannerView.OnAdLoaded += HandleAdOpened;
		bannerView.OnAdClosed += HandleAdClosed;
		bannerView.OnAdLeavingApplication += HandleAdLeftApplication;
		// Load a banner ad.
		bannerView.LoadAd(createAdRequest());
		}
		public void BannerBL()
		{
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = banner_ID;
		#elif UNITY_IOS
		string adUnitId = bannerIOS_ID;
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create a 320x50 banner at the top of the screen.
		bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.BottomLeft);
		// Register for ad events.
		bannerView.OnAdLoaded += HandleAdLoaded;
		bannerView.OnAdFailedToLoad += HandleAdFailedToLoad;
		bannerView.OnAdLoaded += HandleAdOpened;
		bannerView.OnAdClosed += HandleAdClosed;
		bannerView.OnAdLeavingApplication += HandleAdLeftApplication;
		// Load a banner ad.
		bannerView.LoadAd(createAdRequest());
		}
		public void BannerBR()
		{
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = banner_ID;
		#elif UNITY_IOS
		string adUnitId = bannerIOS_ID;
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create a 320x50 banner at the top of the screen.
		bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.BottomRight);
		// Register for ad events.
		bannerView.OnAdLoaded += HandleAdLoaded;
		bannerView.OnAdFailedToLoad += HandleAdFailedToLoad;
		bannerView.OnAdLoaded += HandleAdOpened;
		bannerView.OnAdClosed += HandleAdClosed;
		bannerView.OnAdLeavingApplication += HandleAdLeftApplication;
		// Load a banner ad.
		bannerView.LoadAd(createAdRequest());
		}
    public void RequestInterstitial()
    {
        #if UNITY_EDITOR
            string adUnitId = "unused";
        #elif UNITY_ANDROID
            string adUnitId = inter_ID;
#elif UNITY_IOS
            string adUnitId = interIOS_ID;
#else
            string adUnitId = "unexpected_platform";
#endif

            // Create an interstitial.
        interstitial = new InterstitialAd(adUnitId);
        // Register for ad events.
        interstitial.OnAdLoaded += HandleInterstitialLoaded;
        interstitial.OnAdFailedToLoad += HandleInterstitialFailedToLoad;
        interstitial.OnAdOpening += HandleInterstitialOpened;
        interstitial.OnAdClosed += HandleInterstitialClosed;
        interstitial.OnAdLeavingApplication += HandleInterstitialLeftApplication;
        // Load an interstitial ad.
        interstitial.LoadAd(createAdRequest());
    }

    // Returns an ad request with custom ad targeting.
    private AdRequest createAdRequest()
    {
        return new AdRequest.Builder().Build();
    }

    public void RequestRewardBasedVideo()
    {
        #if UNITY_EDITOR
            string adUnitId = "unused";
        #elif UNITY_ANDROID
		string adUnitId = "Reward_Video_ID";
        #elif UNITY_IPHONE
            string adUnitId = "INSERT_IOS_REWARD_BASED_VIDEO_AD_UNIT_ID_HERE";
        #else
            string adUnitId = "unexpected_platform";
        #endif
		AdRequest req = new AdRequest.Builder ().Build ();
		this.rewardBasedVideo.LoadAd(req, adUnitId);
    }

    public void ShowInterstitial()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
            RequestInterstitial();
        }
        else
        {
            RequestInterstitial();
            print("Interstitial is not ready yet.");
        }
    }

    public void ShowRewardBasedVideo()
    {

        if (rewardBasedVideo.IsLoaded())
        {
			Debug.Log ("rewarded chL PARA");
			VehicleSelection.instance.GiveReward();
			VehicleSelection.instance.RewardedSuccess.SetActive(true);		
			//CallingAds.instance.rewardedsucceded.SetActive (true);
			rewardBasedVideo.Show();
        } else
        {
		Debug.Log ("rewarded NAI CHALA");
			VehicleSelection.instance.RewardedFailed.SetActive(true);
	//	CallingAds.instance.rewardedfailed.SetActive (true);
            print("Reward based video ad is not ready yet.");
        }
    }

    public void HideBanner()
    {
        bannerView.Destroy();
    }

    #region Banner callback handlers

    public void HandleAdLoaded(object sender, EventArgs args)
    {
        print("HandleAdLoaded event received.");
    }

    public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        print("HandleFailedToReceiveAd event received with message: " + args.Message);
       
    }

    public void HandleAdOpened(object sender, EventArgs args)
    {
        print("HandleAdOpened event received");
    }

    void HandleAdClosing(object sender, EventArgs args)
    {
        print("HandleAdClosing event received");
    }

    public void HandleAdClosed(object sender, EventArgs args)
    {
        print("HandleAdClosed event received");
    }

    public void HandleAdLeftApplication(object sender, EventArgs args)
    {
        print("HandleAdLeftApplication event received");
    }

    #endregion

    #region Interstitial callback handlers

    public void HandleInterstitialLoaded(object sender, EventArgs args)
    {
        print("HandleInterstitialLoaded event received.");
    }

    public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        print("HandleInterstitialFailedToLoad event received with message: " + args.Message);
    }

    public void HandleInterstitialOpened(object sender, EventArgs args)
    {
        print("HandleInterstitialOpened event received");
    }

    void HandleInterstitialClosing(object sender, EventArgs args)
    {
        print("HandleInterstitialClosing event received");
    }

    public void HandleInterstitialClosed(object sender, EventArgs args)
    {
        print("HandleInterstitialClosed event received");
    }

    public void HandleInterstitialLeftApplication(object sender, EventArgs args)
    {
        print("HandleInterstitialLeftApplication event received");
    }

    #endregion

    #region RewardBasedVideo callback handlers

		public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
		}

		public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
		{
		MonoBehaviour.print(
		"HandleRewardBasedVideoFailedToLoad event received with message: "
		+ args.Message);
		}

		public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
		}

		public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
		}

		public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
		}

		public void HandleRewardBasedVideoRewarded(object sender, Reward args)
		{
		string type = args.Type;
		double amount = args.Amount;
		MonoBehaviour.print(
		"HandleRewardBasedVideoRewarded event received for "
		+ amount.ToString() + " " + type);
		}

		public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");

		}
    
    #endregion
}
