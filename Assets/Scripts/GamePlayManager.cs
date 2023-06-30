using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayManager : MonoBehaviour 
{


	public void Restart()
	{
		SceneManager.LoadSceneAsync ("Gameplay");
	}
}
