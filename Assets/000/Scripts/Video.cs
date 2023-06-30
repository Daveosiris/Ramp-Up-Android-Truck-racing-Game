using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class Video : MonoBehaviour {
    public static bool ifVideoDialogue;
    public static bool videoFinished;
	public string UnityAdId;
	public bool TestMode;
    
    void Start()
    {
        ifVideoDialogue = true;
		Advertisement.Initialize (UnityAdId,TestMode);

		if (Advertisement.isInitialized) 
		{
			Debug.Log ("Initilaised");
		}


    }
    void OnMouseDown()
    {     
        {
            ShowRewardedAd();
            Destroy(GameObject.Find("VideoAdDialogue(Clone)"));
           
        }
    }

    public void ShowRewardedAd()
    {
        Debug.Log(Advertisement.IsReady("rewardedVideo"));

        if (Advertisement.IsReady("rewardedVideo"))
        {
            Debug.Log(" RewardedAds Loaded");
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);

        }
        else
        {
            Debug.Log(" Rewarded Sprru No Add");
			VehicleSelection.instance.RewardedFailed.SetActive(true);
            videoFinished = true;
        }
    }

	public void ShowAd()
	{
		if (Advertisement.IsReady())
		{
			Debug.Log(" unity add");
			Advertisement.Show();

		}
		else
		{

			Debug.Log(" unity No Add");
			//CallingAds.instance.rewardedsucceded.SetActive (false);
			videoFinished = true;

		}


	}

	private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
				Debug.Log("The ad was successfully shown.");
				VehicleSelection.instance.GiveReward();
				VehicleSelection.instance.RewardedSuccess.SetActive(true);							
			//int currentTime = System.DateTime.Now.Hour
			//	transform.position = new Vector3 (331.4059f,83.17416f,139.2782f);
			//	 YOUR CODE TO REWARD THE GAMER
			//	 Give coins etc.
			//RandomPicker.hintcount=5;
			videoFinished=true;
			Debug.Log ("Level Unlock");


			break;
		case ShowResult.Skipped:
			Debug.Log ("The ad was skipped before reaching the end.");
			videoFinished = true;
			break;
		case ShowResult.Failed:
			Debug.LogError ("The ad failed to be shown.");
			videoFinished = true;
			break;
		}
	}
}
