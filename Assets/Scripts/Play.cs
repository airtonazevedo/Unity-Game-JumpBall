using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Play : MonoBehaviour {

	// Use this for initialization
    
    public Texture btnTexture;
    public float x1;
    public float y1;
    public float h1;
    public float w1;
    private GUIStyle buttonStyle;
    public string nome;
    void OnGUI()
    {
        float h, w, x, y;
        
        h = Screen.height * h1;
        w = h + w1*Screen.height;

        x = Screen.width / 2 - w / 2 + x1 * Screen.width;
        y = Screen.height / 2 - w / 2 + y1*Screen.height;

        

        if (!btnTexture)
        {
            Debug.LogError("Please assign a texture on the inspector");
            return;
        }
        if (GUI.Button (new Rect (x, y, w, h), btnTexture, buttonStyle)) {
				
			if (nome != "") {
			
				transform.parent.SendMessage (nome);
				}
			else{Debug.Log("Nome!");}
		}
       

    }

    void Awake() {
        buttonStyle = new GUIStyle();
        buttonStyle.imagePosition = ImagePosition.ImageOnly;
       
    }
}
