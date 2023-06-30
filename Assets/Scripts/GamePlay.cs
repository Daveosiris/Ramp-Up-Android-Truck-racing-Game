using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic; 
namespace EVP
{

public class GamePlay : MonoBehaviour {

    public GameObject CameraTarget;
	
	[HideInInspector]public int cameraPosition;
	[HideInInspector]public bool  startPosition = false;
	[HideInInspector]public bool endPosition = false;
	[HideInInspector]public float mytime;
    

	public GameObject PauseMenu;
    public GameObject PlayNow;  
	public Text earningText;
    public Text LevelNoText;
	public AudioClip click;
	bool isLevelSeven = false; 
	public GameObject Loading;
	public GameObject Loader;
	public int levelPrefs;
	private int vehiclePref;
	public GameObject controls;
    public GameObject RCC_Cam;
    public GameObject StartingCam;
	public GameObject[] PrefabsLevel;
	public GameObject GameComplete;
	public GameObject GameOver;
	public GameObject[] Cars;
	public Slider slider;
	public GameObject FailedImage;
	public GameObject GameplayMusic;
    private int controlId;
	public static GamePlay instance;
	void Awake()
	{
		instance = this;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
		levelPrefs = PlayerPrefs.GetInt("Level");
		vehiclePref = PlayerPrefs.GetInt ("Vehicle");
            if (PlayerPrefs.GetInt("controls")==0)
            {
                PlayerPrefs.SetInt("controls",1);
            }
	}
	void Start () 
	{
		RCC_UIDashboardDisplay.instance.displayType = RCC_UIDashboardDisplay.DisplayType.Off;
        controls.SetActive(false);
        StartingCam.SetActive(true);
         RCC_Cam.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Camera>().enabled = false;
		PrefabsLevel[levelPrefs-1].SetActive(true);
		Cars [vehiclePref - 1].SetActive (true);
		cameraPosition = 1;
        LevelNoText.text = "Level " + levelPrefs;
	} 
	public void switchCameraFunction()
	{
		playClickSound ();
		CameraTarget = GameObject.FindWithTag ("MainCamera");

		switch (cameraPosition)
		{
		case 1: 
		Cars [vehiclePref - 1].gameObject.transform.GetChild (1).transform.GetChild (1).gameObject.SetActive (true);
			cameraPosition++;
			break;
		case 2:
		Cars [vehiclePref - 1].gameObject.transform.GetChild (1).transform.GetChild (1).gameObject.SetActive (false);
			cameraPosition = 1;
			break;
		}

	}

		public void ChangeCamera()
		{
			Cars [vehiclePref - 1].gameObject.transform.GetChild (1).transform.GetChild (1).gameObject.SetActive (true);
		}
		
	void Update () 
	{
			earningText.text = "$" + (300 * levelPrefs);
	}
	void playClickSound()
	{
		this.gameObject.GetComponent<AudioSource>().PlayOneShot(click);
	}

	public void LevelComplete()
	{    		
		PlayerPrefs.SetInt ("TotalEarning",PlayerPrefs.GetInt("TotalEarning")+(300*levelPrefs));
		PlayerPrefs.SetInt ("wincount",PlayerPrefs.GetInt("wincount")+1);
		GameComplete.SetActive (true);
		HandleLockSystem ();

     }
	public void HandleLockSystem()
	{
		if (PlayerPrefs.GetInt("UnlockedLevel") == PlayerPrefs.GetInt("Level"))
		{
			PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel") + 1);
		}

	}
        public void GameFailed()
	{
		GameOver.SetActive (true);
	}
	public void restart()
	{
		playClickSound ();
		CallingAds.instance.ShowAdmobInter ();                               
		Time.timeScale = 1.0f; 
		Loading.SetActive (true); 
		StartCoroutine (Wait2());
	}

	public void pauseFunction()
	{ 
		playClickSound ();
			CallingAds.instance.ShowAdmobInter();
        gameObject.GetComponent<AudioSource>().enabled = false;
		PauseMenu.SetActive(true);
		gameObject.GetComponent<AudioSource> ().enabled = false;
		Time.timeScale = 0;
	}
	public void Menu()
	{
		CallingAds.instance.Showunityadd ();                                   
		playClickSound ();
		Time.timeScale = 1.0f;
		Loading.SetActive (true);
		StartCoroutine (Wait1());; 
	}
	public void resumeFunction()
	{
		PauseMenu.SetActive(false);
        gameObject.GetComponent<AudioSource>().enabled = true;
		gameObject.GetComponent<AudioSource> ().enabled = true;
		Time.timeScale = 1.0f; 
	}
	public void Next()
	{
		if (PlayerPrefs.GetInt ("Level") <=15) 
		{
                CallingAds.instance.ShowAdmobInter();
                Loading.SetActive (true);
			PlayerPrefs.SetInt ("Level", PlayerPrefs.GetInt ("Level") + 1); 
			StartCoroutine (Wait2 ()); 
		} else 
		{
		   CallingAds.instance.Showunityadd ();
			StartCoroutine (Wait1());

		}
	}
	IEnumerator Wait2()
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync ("GamePlay");
		while(!operation.isDone)
		{
			float progress = Mathf.Clamp01 (operation.progress/0.9f);
			slider.value = progress;
			yield return null;
		}
	}
        IEnumerator Wait1()
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync ("MainMenu");
		while(!operation.isDone)
		{
			float progress = Mathf.Clamp01 (operation.progress/0.9f);
			slider.value = progress;
			yield return null;
		}
	}
        public void okObjective()
        {
            PlayNow.SetActive(false);
			RCC_UIDashboardDisplay.instance.displayType = RCC_UIDashboardDisplay.DisplayType.Full;
			RCC_Cam.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Camera>().enabled = true;
            StartingCam.SetActive(false);
            controls.SetActive(true);         
        }
}
}