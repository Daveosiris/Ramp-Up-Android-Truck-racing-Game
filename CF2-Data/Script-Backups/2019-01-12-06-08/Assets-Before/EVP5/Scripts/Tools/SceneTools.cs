//------------------------------------------------------------------------------------------------
// Edy's Vehicle Physics
// (c) Angel Garcia "Edy" - Oviedo, Spain
// http://www.edy.es
//------------------------------------------------------------------------------------------------

#if !UNITY_5_0 && !UNITY_5_1 && !UNITY_5_2
#define UNITY_53_OR_GREATER
#endif

using UnityEngine;
using System.Collections;
#if UNITY_53_OR_GREATER
using UnityEngine.SceneManagement;
#endif


namespace EVP
{

public class SceneTools : MonoBehaviour
	{
	public bool slowTimeMode = false;
	public float slowTime = 0.3f;

	public KeyCode hotkeyReset = KeyCode.R;
	public KeyCode hotkeyTime = KeyCode.T;

	// Use this for initialization
	void Start ()
		{

		}

	// Update is called once per frame
	void Update ()
		{
		if (Input.GetKeyDown(hotkeyReset))
			{
			#if UNITY_53_OR_GREATER
			SceneManager.LoadScene(0, LoadSceneMode.Single);
			#else
			Application.LoadLevel(0);
			#endif
			}

		if (Input.GetKeyDown(hotkeyTime))
			slowTimeMode = !slowTimeMode;

		Time.timeScale = slowTimeMode? slowTime : 1.0f;
		}
	}
}