using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour 
{
	string message = string.Empty;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI()
	{
		Rect rect = new Rect();
		rect.width = 100;
		rect.height = 40;
		rect.x = Screen.width - rect.width;
		rect.y = Screen.height - rect.height;
		if(GUI.Button(rect, "Check Win"))
		{
			ResultManager.Instance.ShowResultBox(true,Random.Range(1,4),new CallbackFunction[]{DoChooseLevels,DoReplay,DoNextLevel});
		}
		rect.x -= rect.width;
		if(GUI.Button(rect, "Check Lose"))
		{
			ResultManager.Instance.ShowResultBox(false,0,new CallbackFunction[]{DoChooseLevels,DoReplay});
		}
		rect.width = 200;
		rect.x -= Screen.width/2-rect.width/2;
		rect.y =0;		
		GUI.Label(rect, message);
	}
	void DoChooseLevels()
	{
		message = "Click choose levels button";
	}
	void DoReplay()
	{
		message = "Click replay button";
	}
	void DoNextLevel()
	{
		message = "Click next level button";
	}
}
