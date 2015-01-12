using UnityEngine;
using System.Collections;
using Assets.Plugins.SmartLevelsMap.Scripts;
using System;

[ExecuteInEditMode]
public class MapaLevel_inf : MonoBehaviour {

	public Camera CM;
    public GameObject Tempo;
    public GameObject Fase;
    public GameObject Estrela1;
    public GameObject Estrela2;
    public GameObject Estrela3;
    public GameObject Confirmacao;
    public GameObject Confirmacao2;
    public GameObject Confirmacao3;
    public GameObject Numvidas;
    public GameObject Numvidas2;




    private int SelectedLevelNumber;
		  
	// Use this for initialization
	void OnEnable()
	{
        if (PlayerPrefs.GetInt("Vidas") < 1)
        {
            PlayerPrefs.SetInt("Vidas", 0);
			
			//LevelsMap.ChangeIsClickEnabled(false);
            Confirmacao2.SetActive(true);
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

		if (LevelsMap.GetIsConfirmationEnabled() && !LevelsMap.IsLevelLocked(e.Number) && PlayerPrefs.GetInt("Vidas") > 0)
        {
			LevelsMap.ChangeIsClickEnabled(false);
            Confirmacao.SetActive(true);
			SelectedLevelNumber = e.Number;
		    Fase.GetComponent<TextMesh>().text = "Fase " + SelectedLevelNumber.ToString();
            Tempo.GetComponent<TextMesh>().text = String.Format("{0:0.00}", Banco.fases[SelectedLevelNumber - 1].tempo);
            if (Banco.fases[SelectedLevelNumber - 1].NumeroDeEstrelas() == 0)
            {
                Estrela1.GetComponent<SpriteRenderer>().sprite = Resources.Load("EstrelaM", typeof(Sprite)) as Sprite;
                Estrela2.GetComponent<SpriteRenderer>().sprite = Resources.Load("EstrelaM", typeof(Sprite)) as Sprite;
                Estrela3.GetComponent<SpriteRenderer>().sprite = Resources.Load("EstrelaM", typeof(Sprite)) as Sprite;

            }
            if(Banco.fases[SelectedLevelNumber-1].NumeroDeEstrelas() == 1)
            {
                Estrela1.GetComponent<SpriteRenderer>().sprite = Resources.Load("EstrelaD", typeof(Sprite)) as Sprite;
                Estrela2.GetComponent<SpriteRenderer>().sprite = Resources.Load("EstrelaM", typeof(Sprite)) as Sprite;
                Estrela3.GetComponent<SpriteRenderer>().sprite = Resources.Load("EstrelaM", typeof(Sprite)) as Sprite;
           
           
            }
            if (Banco.fases[SelectedLevelNumber - 1].NumeroDeEstrelas() == 2)
            {
                Estrela1.GetComponent<SpriteRenderer>().sprite = Resources.Load("EstrelaD", typeof(Sprite)) as Sprite;
                Estrela2.GetComponent<SpriteRenderer>().sprite = Resources.Load("EstrelaD", typeof(Sprite)) as Sprite;
                Estrela3.GetComponent<SpriteRenderer>().sprite = Resources.Load("EstrelaM", typeof(Sprite)) as Sprite;
           
            }
            if (Banco.fases[SelectedLevelNumber - 1].NumeroDeEstrelas() == 3)
            {
                Estrela1.GetComponent<SpriteRenderer>().sprite = Resources.Load("EstrelaD", typeof(Sprite)) as Sprite;
                Estrela2.GetComponent<SpriteRenderer>().sprite = Resources.Load("EstrelaD", typeof(Sprite)) as Sprite;
                Estrela3.GetComponent<SpriteRenderer>().sprite = Resources.Load("EstrelaD", typeof(Sprite)) as Sprite;
            }
            if (Banco.fases[SelectedLevelNumber - 1].tempo == -1)
            {
                Tempo.GetComponent<TextMesh>().text = "  ";
         
            }
			
		}
        else if (PlayerPrefs.GetInt("Vidas") == 0)
        {
			
			LevelsMap.ChangeIsClickEnabled(false);
            Confirmacao2.SetActive(true);
        }
	}

    void Estrelas()
    {
        Application.LoadLevel(0);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {

            Vector2 mousePosition = CM.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);
             try
            {
			    if (hitCollider.name == "BotaoJogar")
                {
            
                    Estrela1.GetComponent<SpriteRenderer>().sprite = Resources.Load("EstrelaM", typeof(Sprite)) as Sprite;
                Estrela2.GetComponent<SpriteRenderer>().sprite = Resources.Load("EstrelaM", typeof(Sprite)) as Sprite;
                Estrela3.GetComponent<SpriteRenderer>().sprite = Resources.Load("EstrelaM", typeof(Sprite)) as Sprite;
					
					LevelsMap.ChangeIsClickEnabled(true);
                Confirmacao.SetActive(false);
                   LevelsMap.GoToLevel(SelectedLevelNumber);
                 }
                if (hitCollider.name == "X1")
                {
					
					LevelsMap.ChangeIsClickEnabled(true);
                    Confirmacao2.SetActive(false);
                    Confirmacao3.SetActive(false);
          
                    Estrela1.GetComponent<SpriteRenderer>().sprite = Resources.Load("EstrelaM", typeof(Sprite)) as Sprite;
                    Estrela2.GetComponent<SpriteRenderer>().sprite = Resources.Load("EstrelaM", typeof(Sprite)) as Sprite;
                    Estrela3.GetComponent<SpriteRenderer>().sprite = Resources.Load("EstrelaM", typeof(Sprite)) as Sprite;

                    Confirmacao.SetActive(false);
                }
                if (hitCollider.name == "BotaoVidasGratis")
                {
					
					LevelsMap.ChangeIsClickEnabled(true);
                    Debug.Log("Video ganha vidas");
                    PlayerPrefs.SetInt("Vidas", PlayerPrefs.GetInt("Vidas") + 50);
                    Confirmacao2.SetActive(false);
                    Confirmacao3.SetActive(false);
          
                }
                if (hitCollider.name == "BotaoComprarVidas")
                {
					
					LevelsMap.ChangeIsClickEnabled(true);
                    Debug.Log("Comprar vidas");
                    PlayerPrefs.SetInt("Vidas", PlayerPrefs.GetInt("Vidas") + 100);
                    Confirmacao2.SetActive(false);
                    Confirmacao3.SetActive(false);
          
                    
                }

            }
            catch { }
        }
	}

    void Vidas()
    {
		
		LevelsMap.ChangeIsClickEnabled(false);
        Numvidas.GetComponent<TextMesh>().text = PlayerPrefs.GetInt("Vidas").ToString();
        Numvidas2.GetComponent<TextMesh>().text = "Você tem " + PlayerPrefs.GetInt("Vidas").ToString() + " vidas";
        Confirmacao3.SetActive(true);
    }

   

}
