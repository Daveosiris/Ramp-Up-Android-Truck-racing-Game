using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
	Camera maincamera;
	public GameObject exitDialog;
	public GameObject Loading;
	public GameObject MainMenupanel;
	public GameObject mainmenuscript;
	public GameObject VehicleSelectionPanel;
	public GameObject VehicleSelectionAScript;
	public GameObject LevelSelectionPanel;
	public GameObject LevelSelectionScript;
	public GameObject SplitScreenPanel;
	public GameObject RateUsDialog;
	public AudioClip click; 

	void OnEnable()
	{
		CallingAds.instance.bannerTR ();                                       
		int showratDialog = PlayerPrefs.GetInt("ShowRateDialog", 1);
		int alreadyRated = PlayerPrefs.GetInt("AlreadyRated");
		if (alreadyRated == 1) 
		{
			RateUsDialog.SetActive (false);
		}
		else
			if (alreadyRated == 0)
			{
				if (showratDialog % 3 == 0)
				{
					ShowRateDialog();
				}
			}
		showratDialog++;
		PlayerPrefs.SetInt("ShowRateDialog", showratDialog);
	}

	void Awake()
	{
		maincamera = Camera.main;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

	public void ShowRateDialog()
	{
		RateUsDialog.SetActive(true);

	}
	void playClickSound()
	{
		this.gameObject.GetComponent<AudioSource>().PlayOneShot(click);
	}

	public void RateUsButton()
	{
		playClickSound ();
		PlayerPrefs.SetInt("AlreadyRated", 1);
		Application.OpenURL("");
	}

	public void Exit()
	{
		exitDialog.SetActive(true);
	}

	public void ExitDialogYesButton()
	{
		playClickSound ();
		Application.Quit();
	}
	public void ExitDialogNoButton()
	{
		playClickSound ();
		exitDialog.SetActive(false);
	}
	void Update () 
	{
		if(Input.GetKey(KeyCode.Escape)){
			exitDialog.SetActive (true);
		}		
	}
	public void Play()
	{
		//playClickSound ();
      CallingAds.instance.HideBaner ();                                                  
	  CallingAds.instance.ShowAdmobInter ();
		SplitScreenPanel.SetActive(true);
		Invoke("CallToPlay",1.3f);
		Invoke("OffSplitScreen", 2.5f);
		//CallToPlay();
	}
	public void CallToPlay() 
	{
		mainmenuscript.SetActive(false);
		VehicleSelectionAScript.SetActive(true);
		MainMenupanel.SetActive(false);
		VehicleSelectionPanel.SetActive(true);	
		LevelSelectionScript.SetActive(false);
		LevelSelectionPanel.SetActive(false);		
	}
	void OffSplitScreen() 
	{
		SplitScreenPanel.SetActive(false);
	}

	public void RateUsNow()
	{
		PlayerPrefs.SetInt("AlreadyRated", 1);
		RateUsDialog.SetActive (false);
		Application.OpenURL("");
	}
	public void MoreAppButton()
	{
		playClickSound ();
		Application.OpenURL("");
	}
}
