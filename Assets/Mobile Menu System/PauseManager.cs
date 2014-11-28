using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode()] 
public class PauseManager : MonoBehaviour {
	public GUISkin guiskin;
	public static bool isShow = false;
	public static bool isShowHelp = false;
	float maxRight = - Screen.width/4.0f;
	float maxButtonRight = -Screen.width/4.0f;
	float maxLeft = Screen.width;
	public Texture boxBg;
	public List<Texture> textures = new List<Texture>();
	public List<Texture> helpBox = new List<Texture>();
	public Texture pauseButton;
	float scaleWidth = 60.0f;
	int currentHelpPage = 0;
	// Use this for initialization
	void Start () {		
	}
	
	void OnGUI()
	{
		GUI.depth = -2;
		GUI.skin = guiskin;
		DrawButton();
		if(isShowHelp)
			DrawHelp();
	}
	
	void DrawButton()
	{

        if (isShow)
        {
            Time.timeScale = 0;
        }
		//if(isShow)
		{
			//Draw background
			GUI.DrawTexture(new Rect(maxRight,-Screen.height/20.0f,Screen.width/4.0f,Screen.height*1.1f),boxBg);
			//Draw level label
			GUI.Label(new Rect(maxButtonRight + Screen.width/8 - 75,Screen.height/8f,150,Screen.height/12f),"");
			//Calculate buttons' width
			scaleWidth = Screen.height/6f;
			//Draw list levels button
			if(GUI.Button(new Rect(maxButtonRight + Screen.width/8 - scaleWidth/2,Screen.height*2/10.0f,scaleWidth,scaleWidth),textures[0],"trans_button"))
			{
                Debug.Log("menu");
                Time.timeScale = 1;
                GameplayScript.DoChooseLevels();
				isShow = false;
				
				//--------------------------------
				//Load list level in here
				//--------------------------------
			}
			//Draw replay button
			if(GUI.Button(new Rect(maxButtonRight  + Screen.width/8 - scaleWidth/2,Screen.height*4/10.0f,scaleWidth,scaleWidth),textures[1],"trans_button"))
			{
                Debug.Log("restart");
                Time.timeScale = 1;
                GameplayScript.DoReplay();
				isShow = false;
				
				//------------------------------
				//Do replay function in here
				//-----------------------------
			}
			//Draw sound button
			Texture soundButton = SoundEffect.isMute?textures[2]:textures[3];
			if(GUI.Button(new Rect(maxButtonRight  + Screen.width/8 - scaleWidth/2,Screen.height*6/10.0f,scaleWidth,scaleWidth), new GUIContent(soundButton),"trans_button"))
			{

                Debug.Log("som");
                Time.timeScale = 1;
				isShow = false;
				SoundEffect.isMute = !SoundEffect.isMute;
				if(!SoundEffect.isMute)
					SoundEffect.Stop();
				else
					SoundEffect.Play(Sound.tone);
				MusicEffect.isMute = !MusicEffect.isMute;
				if(MusicEffect.isMute)
					MusicEffect.Stop();
				else
					MusicEffect.Play(Music.tone);
			}
			//Draw how to play button
			Texture helpButton = textures[4];
			if(GUI.Button(new Rect(maxButtonRight  + Screen.width/16 - scaleWidth/2,Screen.height*8/10.0f,scaleWidth,scaleWidth),new GUIContent(helpButton),"trans_button"))
			{

                Debug.Log("?");

				//isShow = false;
				isShowHelp = true;
			}			
			//Draw info button
			Texture infoButton = textures[5];
			if(GUI.Button(new Rect(maxButtonRight + Screen.width*3/16 - scaleWidth/2,Screen.height*8/10.0f,scaleWidth,scaleWidth),new GUIContent(infoButton),"trans_button"))
			{

                Debug.Log("!");
                Time.timeScale = 1;
                isShow = false;
				//Application.OpenURL("http://www.odigamestudio.com");
			}
			//Draw transparent area
			if(isShow && GUI.Button(new Rect(maxLeft,0,Screen.width*3/4.0f,Screen.height),"","trans_button"))
			{

                Debug.Log("fora");
                Time.timeScale = 1;
				isShow = false;
			}
		}
		//Draw pauseButton
		if(GUI.Button(new Rect(5,5,scaleWidth*5/7f,scaleWidth*5/7f),pauseButton,"trans_button"))
		{
            Debug.Log("pause");
			isShow = !isShow;
            Time.timeScale = 1;
		}
       
	}
	//Draw help boxes
	void DrawHelp()
	{
		GUI.Box(new Rect(0,0,Screen.width,Screen.height),"","trans_box");
		Rect rect = new Rect();
		float height = Screen.height/1.1f;
		float width = height * 1.5f;
		rect.height = height;
		rect.width = width;
		rect.x = Screen.width/2 - width/2;
		rect.y = Screen.height/2 - height/2;
		GUI.Box(rect,new GUIContent(helpBox[currentHelpPage+1]),"trans_button");
		rect.width = 50;
		rect.height = 50;
		rect.x = Screen.width/2 + width/2 - 100;
		rect.y = Screen.height/2 + height/2 -30;
		if(GUI.Button(rect,new GUIContent(helpBox[0]),"trans_button"))
		{

            isShowHelp = false;
            isShow = false;
            Time.timeScale = 1;
		}
	}
	// Update is called once per frame
	void Update () 
	{
		if(isShow)
		{
			if(maxRight < 0)
			{
				maxRight += 30.0f;
				maxButtonRight += 30.0f;
				if(maxRight > 0)
					maxRight = 0;
				if(maxButtonRight > 0)
					maxButtonRight = 0;
			}
			if(maxLeft > Screen.width/4)
			{
				maxLeft -= 90.0f;
				if(maxLeft < Screen.width/4.0f)
					maxLeft = Screen.width/4.0f;
			}
		}
		if(!isShow)
		{
			if(maxRight > -Screen.width/4.0f)
			{
				maxRight -= 30.0f;
				if(maxRight < -Screen.width/4.0f)
					maxRight = -Screen.width/4.0f;
				maxButtonRight -= 30.0f;
				if(maxButtonRight < -Screen.width/4.0f)
					maxButtonRight = -Screen.width/4.0f;
			}
			if(maxLeft < Screen.width)
			{
				maxLeft += 90.0f;
				if(maxLeft > Screen.width)
					maxLeft = Screen.width;
			}
			if(maxRight == -Screen.width/4.0f && maxLeft == Screen.width)
				isShow = false;
		}
	}
}
