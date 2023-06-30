using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeRotate : MonoBehaviour {

    public float x, y, z;
	
	// Update is called once per frame
	void Update () 
	{
		this.gameObject.transform.Rotate (x,y,z);	
	}
}
