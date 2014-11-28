using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public delegate void CallbackFunction();    
public class ResultManager : MonoBehaviour 
{
	static ResultManager instance;
	
	public GUISkin guiSkin;
	public Texture boxCompleteBackground;
	public Texture boxFailedBackground;
	public Texture chooseLevelTexture;
	public Texture replayTexture;
	public Texture nextTexture;
	public Texture starTexture;	
	
	public List<CallbackFunction> callbackFunctions = new List<CallbackFunction>();
	
	public static float width = 1;
	public static float height = 1;

	bool win = false;
	bool lose = false;
	
	bool isCountTime = false;
	
	int numberOfStar = 0;
	int currentShowStar = 0;
	float holdCount;
	Vector2 startPos;
	float scale = 0f;
	///<Summary>
	///This property will be get from outside of this class like this ResultManager.Instance
	///<Summary>
	public static ResultManager Instance
	{
		get
		{
			if(instance == null)
			{
				GameObject obj = GameObject.Find("ResultManager");
				if(obj ==null)
				{
					obj = (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/ResultManager"));
					obj.name = "ResultManager";
				}
				instance = obj.GetComponent<ResultManager>();
			}
			return instance;
		}
	}
	void Awake()
	{
	}	
	///<Summary>
	///This function will be called from outside of this class
	/// isWin: state of game, win or lose.
	// star: number of star player get
	/// functions: List of callback functions for each action when click on buttons in this control
	///functions[0]: perform action for Choose Levels button
	///functions[1]: perform action for Replay button
	///functions[2]: perform action for Next Level button
	///</Summary>
	public void ShowResultBox(bool isWin, int star, CallbackFunction[] functions)
	{
		win = isWin	;
		lose = !isWin;
		currentShowStar  = 0;
		scale =0;
		numberOfStar = star;
		callbackFunctions.Clear();
		callbackFunctions.AddRange(functions);
	}
	void OnGUI()
	{		
		GUI.skin = guiSkin;
		
		float scaleY = Screen.height/768f;
		//Set button's width, height equals 1/10 screen height
		float buttonWidth = Screen.height * 0.1f;
		float buttonHeight = Screen.height * 0.1f;
		// if the game result  is lose
		if(lose)
		{
			Rect boxRect = new Rect(Screen.width/2f - Screen.height*0.32f,0, Screen.height*0.65f,Screen.height);
			//Draw box failed as background
			GUI.DrawTexture(boxRect,boxFailedBackground,ScaleMode.ScaleToFit);
			//draw choose levels button
			if(GUI.Button(new Rect(Screen.width/2 - buttonWidth -10,boxRect.height - buttonHeight -10, buttonWidth,buttonHeight),chooseLevelTexture,"trans_button"))
			{
				//Call the choose level callback functions\
				callbackFunctions[0]();
				//hide the box
				lose = false;
				win = false;
				return;
			}
			//draw replay button
			if(GUI.Button(new Rect(Screen.width/2 + 10,boxRect.height - buttonHeight -10, buttonWidth,buttonHeight),replayTexture,"trans_button"))
			{
				//Call the Replay callback functions
				callbackFunctions[1]();
				//hide the box
				lose = false;
				win = false;
				return;
			}
		}		
		// if the game result is win
		if(win)
		{
			Rect boxRect = new Rect(Screen.width/2f - Screen.height*0.32f,0, Screen.height*0.65f,Screen.height);
			//Draw box win as background
			GUI.DrawTexture(boxRect,boxCompleteBackground,ScaleMode.StretchToFill);			
			//calculate star rect
			Rect starRect = new Rect();	
			Vector2 starCenter = new Vector2(Screen.width/2 - 125*scaleY, 250*scaleY);
            if (numberOfStar > 0)
            {
                #region "DRAW STARS"
                //only draw the start before current poping up star
                for (int i = 0; i <= currentShowStar; i++)
                {
                    //if current star is poping up star,  show the poping up action by scale the star				
                    if (i == currentShowStar)
                    {
                        //calculate the current star at this time
                        starRect.width = 50 * scale * scaleY;
                        starRect.height = 50 * scale * scaleY;
                    }
                    //if current star poped up, it has full width, heigh
                    else if (i < currentShowStar)
                    {
                        starRect.width = 100 * scaleY;
                        starRect.height = 100 * scaleY;
                    }
                    //calculate left, top of star rect
                    starRect.x = starCenter.x - starRect.width / 2f;
                    starRect.y = starCenter.y - starRect.height / 2f;
                    //draw star
                    GUI.DrawTexture(starRect, starTexture);
                    //shift right 125 pixels to next star
                    starCenter.x += 125 * scaleY;
                }
                #endregion
            }
			//draw choose levels button
			if(GUI.Button(new Rect(Screen.width/2 - 1.5f*buttonWidth -10,boxRect.height - buttonHeight -10, buttonWidth,buttonHeight),chooseLevelTexture,"trans_button"))
			{
				//Call the choose level callback functions
				callbackFunctions[0]();
				//hide the box
				lose = false;
				win = false;
				return;
			}
			//draw replay button
			if(GUI.Button(new Rect(Screen.width/2 - buttonWidth/2f,boxRect.height - buttonHeight -10, buttonWidth,buttonHeight),replayTexture,"trans_button"))
			{
				callbackFunctions[1]();
				//hide the box
				lose = false;
				win = false;
				return;
			}
			//draw Next Level button
			if(GUI.Button(new Rect(Screen.width/2 + buttonWidth/2f + 10,boxRect.height - buttonHeight -10, buttonWidth,buttonHeight),nextTexture,"trans_button"))
			{			
				callbackFunctions[2]();
				//hide the box
				lose = false;
				win = false;
				return;
			}
		}
	}	
	public void Update()
	{		
		//Count display star
       
		if(win)
		{
			scale += Time.deltaTime*6f;
			if(scale > 2f)
			{
				if(currentShowStar < numberOfStar-1)
				{
                 	currentShowStar++;
					scale = 0f;
				}
				else if(currentShowStar == numberOfStar-1)
                {
					scale = 2f;
                    Time.timeScale = 0;
				}
                
			}
		}
	}

}
