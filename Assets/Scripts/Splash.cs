using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    public Slider slide;
    public float speed;
    private int count;
	public void Start()
	{
		//Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
    public void Update()
    {
        slide.value += Time.deltaTime * speed;
        if (slide.value>=0.75f)
        {
            count++;
            if (count==1)
            {
                LoadMainMenu();
            }
        }
    }
	public void LoadMainMenu()
	{
        Debug.Log("Load");
		SceneManager.LoadSceneAsync ("MainMenu");
	}
}
