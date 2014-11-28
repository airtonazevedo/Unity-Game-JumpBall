using UnityEngine;
using System.Collections;

public class fases : MonoBehaviour {

    public Texture btnTexture;
    public float x1;
    public float y1;
    public float h1;
    public float w1;
    public float dy;
    private GUIStyle buttonStyle;
    void OnGUI()
    {
        string[] nome = new string[15];
        float h, w, x, y;

        h = Screen.height * h1;
        w = h + w1 * Screen.height;


        y = Screen.height / 2 - w / 2 + y1 * Screen.height;

        for (int i = 0; i < 15; i++)
        {
            nome[i] = "B" + (i + 1).ToString();
            // Debug.Log(nome[i]);
        }

        for (int i = 0; i < 5; i++)
        {
            x = (Screen.width / 6 * (i + 1)) - w / 2;

            if (GUI.Button(new Rect(x, y, w, h), btnTexture, buttonStyle))
            {
                Application.LoadLevel(i+1);
                //transform.parent.SendMessage(nome[i]);
               // PlayerPrefs.SetInt("bola", i);
            }

        }
        y = Screen.height / 2 - w / 2 + (y1 + dy) * Screen.height;

        for (int i = 5; i < 10; i++)
        {
            x = (Screen.width / 6 * (i + 1 - 5)) - w / 2;

            if (GUI.Button(new Rect(x, y, w, h), btnTexture, buttonStyle))
            {

                Application.LoadLevel(i+1);
                //transform.parent.SendMessage(nome[i]);
               // PlayerPrefs.SetInt("bola", i);
            }

        }


        y = Screen.height / 2 - w / 2 + (y1 + 2*dy) * Screen.height;

        for (int i = 10; i < 15; i++)
        {
            x = (Screen.width / 6 * (i + 1 - 10)) - w / 2;

            if (GUI.Button(new Rect(x, y, w, h), btnTexture, buttonStyle))
            {

                Application.LoadLevel(i+1);
              //  transform.parent.SendMessage(nome[i]);
             //   PlayerPrefs.SetInt("bola", i);
            }

        }
    }

    void Awake()
    {
        buttonStyle = new GUIStyle();
        buttonStyle.imagePosition = ImagePosition.ImageOnly;


    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
