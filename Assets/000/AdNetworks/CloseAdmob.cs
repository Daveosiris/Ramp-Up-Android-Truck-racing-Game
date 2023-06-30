using UnityEngine;
using System.Collections;

public class CloseAdmob : MonoBehaviour {

	private GameObject admob;

	private GoogleMobileAdsDemoScript admobScript;

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (this.gameObject);
		admob = GameObject.Find ("AdMob");
		admobScript = admob.GetComponent<GoogleMobileAdsDemoScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {

						//if (Input.GetTouch(0).phase == TouchPhase.Began){
						Vector3 wp = Camera.main.ScreenToWorldPoint (Input.mousePosition);
						//Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
						Vector2 touchPos = new Vector2 (wp.x, wp.y);			
						if (GetComponent<Collider2D>() == Physics2D.OverlapPoint (touchPos)) {
						admobScript.HideBanner();
						
						Destroy(this.gameObject);
						}

				}
	}
}
