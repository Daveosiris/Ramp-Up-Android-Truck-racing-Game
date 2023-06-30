using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;   
public class VehicleSelection : MonoBehaviour
{
 
	public AudioClip click;
	public AudioClip SettingsClick;
    private Camera mainCamera; 
    private bool isLocked;
	public Text price;
    public Text totalEarningTxt;
    public Vector3 cameraOffset;
    public GameObject lockedImage;
    public int activeObjectIdx = 0;
    public GameObject rightButton;
    public GameObject leftButton;
    public GameObject[] vehicleList;
    public int Vehicle2Price = 0;
    public int Vehicle3Price = 0;
    public int Vehicle4Price = 0;
    public int Vehicle5Price = 0;
    public int Vehicle6Price = 0;
    public int Vehicle7Price = 0;
    public GameObject unlockDialog;
    public GameObject insuficientCash;
    public Transform[] Car_Specs;
	public int[] vehiclepricetext;
    public GameObject vehcicleselectionPanel;
    public GameObject mainMenuPanel;
    public GameObject levelSelectionPanel;
    public GameObject loading;
    public GameObject mainMenuScript;
    public GameObject levelSelectionScript;
    public GameObject vehicleSelectionScript;
	public GameObject RewardedSuccess;
	public GameObject RewardedFailed;
	public GameObject PurchasedSuccess;
	public GameObject PurchasedFailed;
    public GameObject SplitScreen;
	public GameObject buyBtn;
    public Vector3 initialPos;

	public static VehicleSelection instance;

    void OnEnable()
    {
        activeObjectIdx = 0;
        Debug.Log("Active Id  is " + activeObjectIdx);
        totalEarningTxt.text = " $ " + PlayerPrefs.GetInt("TotalEarning") + "";
        isLocked = false;
        PlayerPrefs.SetInt("Vehicle1", 1);
    }
    void Awake()
    {  
		instance = this;
        mainCamera = Camera.main;
    }
//	void Start()
//	{
//		
//	}
	void playClickSound()
	{
		this.gameObject.GetComponent<AudioSource>().PlayOneShot(click);
	}

	void SettingsClickSound()
	{
		this.gameObject.GetComponent<AudioSource>().PlayOneShot(SettingsClick);
	}


	public void PurchaseDone()
	{
		        //isLocked = false;
		        //PlayerPrefs.SetInt("Vehicle1", 1);
		        PlayerPrefs.SetInt("Vehicle2", 1);
		        PlayerPrefs.SetInt("Vehicle3", 1);
		        PlayerPrefs.SetInt("Vehicle4", 1);
		        PlayerPrefs.SetInt("Vehicle5", 1);
                PlayerPrefs.SetInt("Vehicle6", 1);
                PlayerPrefs.SetInt("Vehicle7", 1);
        PurchasedSuccess.SetActive (false);
		PlayerPrefs.SetInt ("texture",activeObjectIdx);

	}
    void Update()
    {
        totalEarningTxt.text = " $ " + PlayerPrefs.GetInt("TotalEarning") + "";
        setLeftRightButtons(activeObjectIdx, 0, vehicleList.Length - 1);
        setLocks();
    }

    public void LeftFun()
    {
		SettingsClickSound ();
        activeObjectIdx--;
        if (activeObjectIdx < 0)
            activeObjectIdx = vehicleList.Length - 1;
        setAllGameObjectFalse(vehicleList);
        setGameObjectActive(vehicleList, activeObjectIdx);
		price.text ="$"+vehiclepricetext [activeObjectIdx]+"";
    }

    public void RightFun()
    {
		SettingsClickSound ();
        activeObjectIdx++;
        if (activeObjectIdx >= vehicleList.Length)
            activeObjectIdx = 0;
        setAllGameObjectFalse(vehicleList);
        setGameObjectActive(vehicleList, activeObjectIdx);
		price.text ="$"+vehiclepricetext [activeObjectIdx]+"";
    }

    private void setLeftRightButtons(int number, int min, int max)
    {
        if (number != min && number != max)
        {
            rightButton.SetActive(true);
            leftButton.SetActive(true);
        }
        if (number == min)
        {
            leftButton.SetActive(false);
            rightButton.SetActive(true);
        }
        if (number == max)
        {
            rightButton.SetActive(false);
            leftButton.SetActive(true);
        }
    }

	public void showAd()
	{
		playClickSound ();
		int i = UnityEngine.Random.Range (1,3);
		if(i==1)
		{
			CallingAds.instance.ShowUnityRewardedAd ();
		}
		else if(i==2)
		{
			CallingAds.instance.rewardedadd ();
		}

	}
	public void GiveReward()
	{
		playClickSound ();
		PlayerPrefs.SetInt("TotalEarning", PlayerPrefs.GetInt("TotalEarning") + 500);
	}
	 
    private void showDialogs()
    {
        if (activeObjectIdx == 1 && PlayerPrefs.GetInt("TotalEarning") > Vehicle2Price && PlayerPrefs.GetInt("Vehicle2") == 0)
        {
            unlockDialog.SetActive(true);
        }
        else if (activeObjectIdx == 2 && PlayerPrefs.GetInt("TotalEarning") > Vehicle3Price && PlayerPrefs.GetInt("Vehicle3") == 0)
        {
            unlockDialog.SetActive(true);
        }
        else if (activeObjectIdx == 3 && PlayerPrefs.GetInt("TotalEarning") > Vehicle4Price && PlayerPrefs.GetInt("Vehicle4") == 0)
        {
            unlockDialog.SetActive(true);
        }
        else if (activeObjectIdx == 4 && PlayerPrefs.GetInt("TotalEarning") > Vehicle5Price && PlayerPrefs.GetInt("Vehicle5") == 0)
        {
            unlockDialog.SetActive(true);
        }
        else if (activeObjectIdx == 5 && PlayerPrefs.GetInt("TotalEarning") > Vehicle6Price && PlayerPrefs.GetInt("Vehicle6") == 0)
        {
            unlockDialog.SetActive(true);
        }
        else if (activeObjectIdx == 6 && PlayerPrefs.GetInt("TotalEarning") > Vehicle7Price && PlayerPrefs.GetInt("Vehicle7") == 0)
        {
            unlockDialog.SetActive(true);
        }

        else
        {
            insuficientCash.SetActive(true);
        }
    }

    private void unlockFunction()
    {
        if (activeObjectIdx == 1 && PlayerPrefs.GetInt("TotalEarning") >= Vehicle2Price)
        {
            PlayerPrefs.SetInt("TotalEarning", PlayerPrefs.GetInt("TotalEarning") - Vehicle2Price);
            PlayerPrefs.SetInt("Vehicle2", 1);
			buyBtn.SetActive(false);
            isLocked = true;
        }
        if (activeObjectIdx == 2 && PlayerPrefs.GetInt("TotalEarning") >= Vehicle3Price)
        {
            PlayerPrefs.SetInt("TotalEarning", PlayerPrefs.GetInt("TotalEarning") - Vehicle3Price);
            PlayerPrefs.SetInt("Vehicle3", 1);
			buyBtn.SetActive(false);
            isLocked = true;
        }
        if (activeObjectIdx == 3 && PlayerPrefs.GetInt("TotalEarning") >= Vehicle4Price)
        {
            PlayerPrefs.SetInt("TotalEarning", PlayerPrefs.GetInt("TotalEarning") - Vehicle4Price);
            PlayerPrefs.SetInt("Vehicle4", 1);
			buyBtn.SetActive(false);
            isLocked = true;
        }
        if (activeObjectIdx == 4 && PlayerPrefs.GetInt("TotalEarning") >= Vehicle5Price)
        {
            PlayerPrefs.SetInt("TotalEarning", PlayerPrefs.GetInt("TotalEarning") - Vehicle5Price);
            PlayerPrefs.SetInt("Vehicle5", 1);
            isLocked = true;
        }
        if (activeObjectIdx == 5 && PlayerPrefs.GetInt("TotalEarning") >= Vehicle6Price)
        {
            PlayerPrefs.SetInt("TotalEarning", PlayerPrefs.GetInt("TotalEarning") - Vehicle6Price);
            PlayerPrefs.SetInt("Vehicle6", 1);
            isLocked = true;
        }
        if (activeObjectIdx == 6 && PlayerPrefs.GetInt("TotalEarning") >= Vehicle7Price)
        {
            PlayerPrefs.SetInt("TotalEarning", PlayerPrefs.GetInt("TotalEarning") - Vehicle7Price);
            PlayerPrefs.SetInt("Vehicle7", 1);
            isLocked = true;
        }
    }

    private void setLocks()
    {
		buyBtn.SetActive(false);
        lockedImage.SetActive(false);
        isLocked = false;
        if (activeObjectIdx == 0 && PlayerPrefs.GetInt("Vehicle1") == 0)
        {
			buyBtn.SetActive(true);
            lockedImage.SetActive(true);
            isLocked = true;
        }
        if (activeObjectIdx == 1 && PlayerPrefs.GetInt("Vehicle2") == 0)
        {
			buyBtn.SetActive(true);
            lockedImage.SetActive(true);
            isLocked = true;
        }
        if (activeObjectIdx == 2 && PlayerPrefs.GetInt("Vehicle3") == 0)
        {
			buyBtn.SetActive(true);
            lockedImage.SetActive(true);
            isLocked = true;
        }
        if (activeObjectIdx == 3 && PlayerPrefs.GetInt("Vehicle4") == 0)
        {
			buyBtn.SetActive(true);
            lockedImage.SetActive(true);
            isLocked = true;
        }
        if (activeObjectIdx == 4 && PlayerPrefs.GetInt("Vehicle5") == 0)
        {
			buyBtn.SetActive(true);
            lockedImage.SetActive(true);
            isLocked = true;
        }
        if (activeObjectIdx == 5 && PlayerPrefs.GetInt("Vehicle6") == 0)
        {
            buyBtn.SetActive(true);
            lockedImage.SetActive(true);
            isLocked = true;
        }
        if (activeObjectIdx == 6 && PlayerPrefs.GetInt("Vehicle7") == 0)
        {
            buyBtn.SetActive(true);
            lockedImage.SetActive(true);
            isLocked = true;
        }
    }


    private void setAllGameObjectFalse(GameObject[] mlist)
    {
        for (int i = 0; i < mlist.Length; i++)
        {
            mlist[i].gameObject.SetActive(false);
            mlist[i].transform.position = initialPos;
            Car_Specs[i].gameObject.SetActive(false);
        }
    }
 
    private void setGameObjectActive(GameObject[] mlist, int n)
    {
        Car_Specs[n].gameObject.SetActive(true);
        mlist[n].gameObject.SetActive(true);
    }
    public void BackButtonFun()
    {
		for(int i=0; i<=activeObjectIdx; i++)
		{
            Debug.Log("Working");
			vehicleList[i].SetActive (false);
		}
        vehicleList[0].SetActive(true);
        waitForBack();
    }
    public void CashOKBtnFun()
    {
		playClickSound ();
        insuficientCash.SetActive(false);
    }
    public void UnlockYesFun()
    {
		playClickSound ();
        unlockFunction();
        totalEarningTxt.text = " " + PlayerPrefs.GetInt("TotalEarning") + " $";
        unlockDialog.SetActive(false);
    }
    public void UnlockNoBtn()
    {
		playClickSound ();
        unlockDialog.SetActive(false);
    }
 
    public void NextBtnFun()
    {
        if (isLocked == true)
        {
            showDialogs();
        }
        else
        {
			for(int i=0; i<=activeObjectIdx; i++)
			{
				vehicleList [i].SetActive (false);
			}
            vehicleList[0].gameObject.SetActive(true);
			LoadLevelPanel();	
        }   
    }
    void waitForBack()
    {
        vehcicleselectionPanel.SetActive(false);
        vehicleSelectionScript.SetActive(false);
        mainMenuScript.SetActive(true);     
        levelSelectionScript.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
	public void LoadLevelPanel()
	{
		PlayerPrefs.SetInt("Vehicle", activeObjectIdx + 1);
		PlayerPrefs.SetInt ("texture",activeObjectIdx);
        SplitScreen.SetActive(true);
        Invoke("CallToLoadLevel",1.2f);
        Invoke("OffSplitScreen",2.5f);
	}

    void CallToLoadLevel() 
    {
        mainMenuScript.SetActive(false);
        vehicleSelectionScript.SetActive(false);
        levelSelectionScript.SetActive(true);
        levelSelectionPanel.SetActive(true);
        vehcicleselectionPanel.SetActive(false);
        
    }
    void OffSplitScreen() 
    {
        SplitScreen.SetActive(false);
    }
}