using UnityEngine;
using System.Collections;
//using GooglePlayGames;

public class ShowAchievemnt : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
			//if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			Vector3 touchPosition3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			
			Vector2 touchPosition2 = new Vector2 (touchPosition3.x,touchPosition3.y);			
			if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPosition2))
			{
				
				//GoogleAnalytics.GAActivity.Call("generateGAEvent","UX","touch","LeaderBoard",null);
				if (!Social.localUser.authenticated) {
					Social.localUser.Authenticate ((bool success) => {
						Debug.Log("Authenticated " + success);
                      //  Social.ReportScore();
						Social.ShowAchievementsUI();
					});
				} else

					Social.ShowAchievementsUI();
			}
			
		}
	}
}