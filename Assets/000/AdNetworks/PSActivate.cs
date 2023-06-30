using UnityEngine;
using System.Collections;

public class PSActivate : MonoBehaviour {

	// Use this for initialization
	
	void Awake () {
		//GooglePlayGames.PlayGamesPlatform.Activate();
	}

	void Start () {
		Debug.Log ("IsSignIn " +Social.localUser.authenticated);
		if (!Social.localUser.authenticated) {
			Debug.Log("in SignIN");
						Social.localUser.Authenticate ((bool success) => {
					Debug.Log("Authenticated " + success);
								
						});
				}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
