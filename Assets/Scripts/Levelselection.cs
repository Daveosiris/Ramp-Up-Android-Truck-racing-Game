using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Levelselection : MonoBehaviour {
	public AudioClip click;
	public Button[] levelButton;
	public GameObject backButton; 
	public GameObject loading;
	public int levelNum = 1;
	int unlockLevelNum;
	public GameObject lockDialog;
	public GameObject levelSelectionPanel; 
	public GameObject mainMenuScript;
	public GameObject mainMenuPanel;
	public GameObject levelSelectionScript;
	void Awake()
	{
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
	void OnEnable()
	{ 
	      if (PlayerPrefs.GetInt("UnlockedLevel") == 0)
		{
			PlayerPrefs.SetInt("UnlockedLevel", 1);
			PlayerPrefs.SetString("1", "1 0"); 
			unlockLevelNum = PlayerPrefs.GetInt("UnlockedLevel");
		}
		else
		{
			unlockLevelNum = PlayerPrefs.GetInt("UnlockedLevel"); 
		} 
		levelNum = 1;
		unlockLevels(unlockLevelNum); 
	}

	void playClickSound()
	{
		this.gameObject.GetComponent<AudioSource>().PlayOneShot(click);
	}

	public void nextButtonFunction()
	{
		if(unlockLevelNum >= levelNum)
		{
			loading.SetActive(true);   
			StartCoroutine (Wait());
		}
		else
		{
			lockDialog.SetActive (true);
		}
	}
	IEnumerator Wait()
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync ("GamePlay");
		while(!operation.isDone)
		{
			float progress = Mathf.Clamp01 (operation.progress/0.9f);
			//slide.value = progress;
			yield return null;
		}
	}
	private void unlockLevels(int num)
	{
		for(int i = 0; i < num; i++){
			levelButton [i].transform.GetChild (0).gameObject.SetActive (false);
			levelButton[num-1].gameObject.GetComponent<Animator>().enabled = true;
		}
	}
	public void LoadLevel(string levelName)
	{
		playClickSound (); 
		levelNum = int.Parse(levelName);
		Debug.Log (levelNum);
		PlayerPrefs.SetInt("Level", levelNum);
		if (unlockLevelNum >= levelNum) 
		{
			lockDialog.SetActive (false); 

		}
		else {
			lockDialog.SetActive (true); 
		}
		nextButtonFunction();
	}

	public void OkButtonClick()
	{ 
		playClickSound ();
		lockDialog.SetActive(false);
	}

	public void BackButton()
	{
		playClickSound ();
        CallingAds.instance.Showunityadd();
		loading.SetActive(true); 
		StartCoroutine("WaitforBack");
	}
	IEnumerator WaitforBack()
	{
		yield return new WaitForSeconds(1.0f);
		mainMenuScript.SetActive(true);  
		mainMenuPanel.SetActive(true);
		levelSelectionScript.SetActive(false); 
		levelSelectionPanel.SetActive(false);
		loading.SetActive(false);
		StopCoroutine(WaitforBack());
	}
	public void unlocklevelbutton()
	{ 
		playClickSound ();  	
		PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel") + 1);
		PlayerPrefs.SetInt("unlockleveladd", 1);
		unlockLevelNum = PlayerPrefs.GetInt("UnlockedLevel");
		unlockLevels(unlockLevelNum);

	}
}
