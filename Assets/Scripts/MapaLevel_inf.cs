using UnityEngine;
using System.Collections;
using Assets.Plugins.SmartLevelsMap.Scripts;

[ExecuteInEditMode]
public class MapaLevel_inf : MonoBehaviour {


	// Use this for initialization
	void OnEnable()
	{
        if (PlayerPrefs.GetInt("Vidas") < 1)
        {
            PlayerPrefs.SetInt("Vidas", 0);
        }
      
	//	Debug.Log("Subscribe to events.");
		LevelsMap.LevelSelected += OnLevelSelected;

	}

	public void OnDisable()
	{
				//Debug.Log ("Unsubscribe from events.");
				LevelsMap.LevelSelected -= OnLevelSelected;
	}

    void OnGUI()
    {
		
		float h1 = 0.11f, w1 = 0, x1 = -0.4f,x2=-0.2f, x3 = 0.45f, y1 = -0.435f, fonte=0.03f;
		
		float h, w, x, y;
		string texto1 = "0000", texto2 = "0000", texto3 = "0000";
		
		h = Screen.height * h1;
		w = h + w1*Screen.height;
		
		x = Screen.width / 2 - w / 2 + x1 * Screen.width;
		y = Screen.height / 2 - w / 2 + y1*Screen.height;

		fonte *= Screen.width;

        texto1 = PlayerPrefs.GetInt("Vidas").ToString();
		texto3 = Banco.TotalDeEstrelas().ToString();

		GUI.Label (new Rect (x, y, w*2, h), "<size=" + fonte.ToString () + ">" + texto1 + "</size>");

		x = Screen.width / 2 - w / 2 + x2 * Screen.width;

		GUI.Label (new Rect (x, y, w*2, h), "<size=" + fonte.ToString () + ">" + texto2 + "</size>");

		x = Screen.width / 2 - w / 2 + x3 * Screen.width;

		GUI.Label (new Rect (x, y, w*2, h), "<size=" + fonte.ToString () + ">" + texto3 + "</size>");



        


        
	}

	private void OnLevelSelected(object sender, LevelReachedEventArgs e)
	{
		Debug.Log("asdd");
		if (LevelsMap.GetIsConfirmationEnabled())
		{
			int SelectedLevelNumber = e.Number;
		//	e.
			//ConfirmationView.SetActive(true);
			Debug.Log(SelectedLevelNumber.ToString());
		}
	}

    void Estrelas()
    {
        Application.LoadLevel(0);
    }
	/*
	private void OnNoButtonClick(object sender, EventArgs e)
	{
		ConfirmationView.SetActive(false);
	}
	
	private void OnYesButtonClick(object sender, EventArgs e)
	{
		ConfirmationView.SetActive(false);
		LevelsMap.GoToLevel(SelectedLevelNumber);
	}
*/
	// Update is called once per frame
	void Update () {
	
	}

    void Vidas()
    {
        PlayerPrefs.SetInt("Vidas", 100);
    }

}
