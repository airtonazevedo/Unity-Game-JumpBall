using UnityEngine;
using System.Collections;
using Assets.Plugins.SmartLevelsMap.Scripts;

[ExecuteInEditMode]
public class MapaLevel_inf : MonoBehaviour {

    private GUIStyle gs;
    public Texture2D estrela, coin;
	// Use this for initialization
    void OnGUI()
    {
  
        GUI.backgroundColor = Color.black;
        GUI.Box(new Rect(5, -1, 60, 25), "");
        if (GUI.Button(new Rect(5, -1, 60, 25),"" ))
        {
            Debug.Log("Ar");
        }


        GUI.Box(new Rect(70, -1, 60, 25), "");
        if (GUI.Button(new Rect(70, -1, 60, 25), ""))
        {
            Debug.Log("Dinheiro");
        }


        GUI.Box(new Rect(Screen.width - 65, -1, 60, 25), "");
        if (GUI.Button(new Rect(Screen.width-65, -1, 60, 25), ""))
        {
            Debug.Log("Estrelas");
        }
        GUI.backgroundColor = Color.clear;

        GUI.Box(new Rect(0, -2, 30, 30), coin);
        GUI.Label(new Rect(30, 1, 30, 30), "0000");


        GUI.Box(new Rect(65, -2, 30, 30), coin);
        GUI.Label(new Rect(95, 1, 30, 30), "0000");


        GUI.Box(new Rect(Screen.width-70, -2, 30, 30), estrela);
        GUI.Label(new Rect(Screen.width-40, 1, 30, 30), Banco.TotalDeEstrelas().ToString());
       
    
        


           
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
