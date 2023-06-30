using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureManager : MonoBehaviour 
{
//    public Texture[] textures;
//	public GameObject[] obj;
//	public Renderer[] rend;
//	
//		void Start()
//		{
//		for(int j=0;j<48;j++)
//		{
//			//rend[j] = obj[j].GetComponent<Renderer>();
//		}
//		}
//	
//		public void setTexture(int i)
//		{
//		
//		for(int j=0;j<48;j++)
//		{
//			rend[j] = obj[j].GetComponent<Renderer>();
//			rend[j].material.mainTexture = textures[i-1];
//		}
//			
//		}

	    public Texture[] textures;
		public GameObject obj;
		public Renderer rend;

	void Start()
	{
		obj=this.gameObject;
		rend = obj.transform.GetComponent<Renderer> ();
		Invoke ("Change1",60f);
	}

	public void Change1()
	{	        	
		rend.material.mainTexture = textures[0]; 
		Invoke ("Change2",6f);
	}
	public void Change2()
	{
		rend.material.mainTexture = textures[1]; 
		Invoke ("Change3",60f);
	}

	public void Change3()
	{
		rend.material.mainTexture = textures[2]; 
		Invoke ("Change4",60f);
	}
	public void Change4()
	{
		rend.material.mainTexture = textures[3]; 
		Invoke ("Change5",60f);
	}
	public void Change5()
	{		
		rend.material.mainTexture = textures[4]; 
		Invoke ("Change6",60f);
	}
	public void Change6()
	{		
		rend.material.mainTexture = textures[5]; 
		Invoke ("Change7",60f);
	}
	public void Change7()
	{		
		rend.material.mainTexture = textures[6]; 
		Invoke ("Change8",60f);
	}
	public void Change8()
	{		
		rend.material.mainTexture = textures[7]; 
		Invoke ("Change1",60f);
	}
}
