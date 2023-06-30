using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace EVP
{
public class PlayerTriger : MonoBehaviour 
{

		public float speed;
		public GameObject Player;
        public GameObject PlayerCam;
		public AudioSource WinClap;

		public bool isEnter;
        private GameObject RCC_Cam;

	public void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "park")
		{
				isEnter = true;
				WinClap.Play ();
				//Player.transform.GetChild (1).gameObject.transform.GetChild (0).gameObject.SetActive (true);
               // GamePlay.instance.CameraTarget.SetActive(false);
                GamePlay.instance.controls.SetActive(false);
                //Player.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.SetActive(true);
                other.gameObject.tag = "Untagged";
				other.gameObject.SetActive (false);
                GamePlay.instance.RCC_Cam.transform.GetChild(1).gameObject.SetActive(true);
				Invoke ("Complete",3.5f);
		}
            if (other.gameObject.tag == "vlc")
            {
                RCC_Cam = GameObject.Find("RCCCamera");
               // PlayerCam.SetActive(true);
              //RCC_Cam = GameObject.Find("RCCCamera");
              //other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
             //   RCC_Cam.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Camera>().enabled = false;               
            }
            if (other.gameObject.tag == "fall")
			{
				other.gameObject.tag = "Untagged";
				GamePlay.instance.controls.SetActive(false);
				RCC_UIDashboardDisplay.instance.displayType = RCC_UIDashboardDisplay.DisplayType.Off;
				GamePlay.instance.FailedImage.SetActive(true);
				Invoke ("Fail",4f);
			}
	}

		//void Update()
		//{
			//if(isEnter==true)
			//{
				//Player.transform.GetChild (1).gameObject.transform.GetChild (0).transform.Rotate (0,speed,0);
			//}

		//}

//		public void OnCollisionEnter(Collision other)
	//	{
			//
		//}
		public void Fail()
		{
			GamePlay.instance.GameFailed ();
		}
		public void Complete()
		{
            Debug.Log("Level Completed");
			GamePlay.instance.LevelComplete ();
		}
		//public void OnTriggerStay(Collider other)
		//{
		//	//
		//}
		//public void OnTriggerExit(Collider other)
		//{
		//	//
		//}
}
}
