using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingTexture : MonoBehaviour 
{

	public float scrollSpeed;
	Renderer rend;

	void Start()
	{
		rend = GetComponent<Renderer> ();
	}

	void Update()
	{
		float offset = Time.time * scrollSpeed;
		rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
	}
}
