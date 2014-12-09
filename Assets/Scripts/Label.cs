using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Label : MonoBehaviour {

	public float x1;
	public float y1;
	public float h1;
	public float w1;
	public float fonte = 20;
	public string texto = "";
	public string nome;

	// Use this for initialization
	void OnGUI()
	{
		float h, w, x, y;

		h = Screen.height * h1;
		w = h + w1*Screen.height;
		
		x = Screen.width / 2 - w / 2 + x1 * Screen.width;
		y = Screen.height / 2 - w / 2 + y1*Screen.height;
		
		
			GUI.Label (new Rect (x, y, w, h), "<size=" + fonte.ToString () + ">" + texto + "</size>");
		
		
		
	}

}
