using UnityEngine;
using System.Collections;
using System;
using Assets.Plugins.SmartLevelsMap.Scripts;

public class GameplayScript : MonoBehaviour {
    public GameObject Bola;
    public GUIText Tempo;
    public GameObject Estrelaa;
    public GameObject Estrelab;
    public GameObject Estrelac;
	public string proximafase = "Fase";

    private bool _segurabotaod, _segurabotaol, subir, _vence, _melhortempo, _validatempo;
    private float _velocidade, _velocidadepulo;
    private Vector3 _bolaini, _pos;
    private Sprite tex;
    private float pulo, _contavence;
    public static float temp;
    private string temporeal;
    private bool[] estrelas = new bool[3];

   
	// Use this for initialization
	void Start () {
        tex = Resources.Load((PlayerPrefs.GetInt("bola") + 1).ToString(), typeof(Sprite)) as Sprite;
        Bola.GetComponent<SpriteRenderer>().sprite = tex;
       // Bola.sprite = tex;
     
        

        _pos = Vector3.zero;
        _segurabotaod = false;
        _velocidade = 2.5f;
        _segurabotaol = false;
        _vence = false;
        _bolaini = Bola.transform.position;
        temp = 0;
        _contavence = 1;
        _melhortempo = false;
        estrelas[0] = false;
        estrelas[1] = false;
        estrelas[2] = false;
        _validatempo = true;
      

        foreach (var item in Banco.fases)
        {
            if (item.fase == Application.loadedLevelName)
            {
                tex = Resources.Load("EstrelaOff".ToString(), typeof(Sprite)) as Sprite;
           
                if (item.estrela1)
                {
                    estrelas[0] = true;
                    Estrelaa.GetComponent<SpriteRenderer>().sprite = tex;
  
                }
                if (item.estrela2)
                {
                    estrelas[1] = true;
                    Estrelab.GetComponent<SpriteRenderer>().sprite = tex;
  
                }
                if (item.estrela3)
                {
                    estrelas[2] = true;
                    Estrelac.GetComponent<SpriteRenderer>().sprite = tex;
                }
                Debug.Log(item.ToString());
                break;
            }
        }
	}
    /*
    void OnGUI()
    {
        Texture2D btnTexture, btnTexture2;
        btnTexture = Resources.Load("placa", typeof(Texture2D)) as Texture2D;
        btnTexture2 = Resources.Load("play2", typeof(Texture2D)) as Texture2D;
        
       
        if (_vence)
        {
            

            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
            GUI.backgroundColor = Color.clear;
            GUI.Box(new Rect(0, -Screen.height +_contavence, Screen.width, Screen.height*1.5f), btnTexture);

            if (_contavence < Screen.height)
            {
                _contavence *= 1.04f;
            }
            else
            {
                _contavence = Screen.height;
                GUIStyle centraliza = new GUIStyle("label");
                centraliza.alignment = TextAnchor.MiddleCenter;

                float tamanho = Screen.height * 0.15f;
                Rect r = new Rect(Screen.width/2 - tamanho/2, Screen.height/2+tamanho*0.9f, tamanho, tamanho);
                if (GUI.Button(r, btnTexture2))
                {
                    Time.timeScale = 1;
                    Application.LoadLevel(0);
                }
                r.width = Screen.width;
                r.y -= tamanho * 1.5f;
                r.x = 0;

                GUI.skin.label.fontSize = Convert.ToInt32(Screen.height*0.09f);
                GUI.contentColor = new Color32(250, 250, 210, 255);
                if (_melhortempo)
                {
                    PlayerPrefs.SetString("MelhorTempo", Tempo.text);
              
                    GUI.Label(r, "Novo Recorde!  " + Tempo.text, centraliza);
                    
                }
                else
                {

                    GUI.Label(r, "Melhor tempo: " + PlayerPrefs.GetString("MelhorTempo"), centraliza);
         
                }
            }

        }
    }
    */



    void Reiniciar()
    {
        Bola.renderer.enabled = false;
        Bola.collider2D.isTrigger = true;
        Time.timeScale = 0;
        ResultManager.Instance.ShowResultBox(false, 0, new CallbackFunction[] { DoChooseLevels, DoReplay });
	
    }

    void Vencer()
    {

        Bola.renderer.enabled = false;
        Bola.collider2D.isTrigger = true;
        //Time.timeScale = 0;
        _vence = true;
        
        
        //Application.LoadLevel(2);
    }


    void playmouse()
    {
        if (Input.GetMouseButton(0))
        {
            _pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (_pos.x < 0)
            {
                _segurabotaol = true;
                _segurabotaod = false;
            }
            else
            {
                _segurabotaod = true;
                _segurabotaol = false;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _segurabotaod = false;
            _segurabotaol = false;
        }

    }

    void playteclado()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
                _segurabotaol = true;
                _segurabotaod = false;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
                _segurabotaod = true;
                _segurabotaol = false;
        }
        
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _segurabotaol = false;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            _segurabotaod = false;
        }

    }

    void mover()
    {
        if (_segurabotaod)
        {
            Bola.transform.Translate(Bola.transform.right * Time.deltaTime * _velocidade);
        }
        if (_segurabotaol)
        {
            Bola.transform.Translate(Bola.transform.right * Time.deltaTime * _velocidade * (-1));
        }
    }
	// Update is called once per frame

    void Estrela1()
    {
        PegarEstrela(1);
    }
    void Estrela2()
    {
        PegarEstrela(2);
    }
    void Estrela3()
    {
        StarTempo.v = false;
        PegarEstrela(3);
    }
    void PegarEstrela(int n)
    {
        estrelas[n - 1] = true;
    }

    void PecasColisao()
    {
        Bola.rigidbody2D.velocity = Vector2.up * 4.5f;
    }
    void UpColisao()
    {
        Bola.rigidbody2D.velocity = Vector2.up * 6.5f;
  
    }

	void Update () {
         playmouse();
         playteclado();
        
         mover();
       
         if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("p"))
         {
             PauseManager.isShow = !(PauseManager.isShow);
             Time.timeScale = 1;
         }

         temp += Time.deltaTime;

         if (_vence && _validatempo)
         {
             int nestrelas = 0;
             _validatempo = false;

             FaseClass _fase = new FaseClass(Application.loadedLevelName, temp, estrelas[0], estrelas[1], estrelas[2], true);
             bool achou = false;
            
             Debug.Log(_fase.ToString());
             if (estrelas[0]) { nestrelas++; }
             if (estrelas[1]) { nestrelas++; }
             if (estrelas[2]) { nestrelas++; }
             ResultManager.Instance.ShowResultBox(true, nestrelas, new CallbackFunction[] { DoChooseLevels, DoReplay, DoNextLevel });

             try
             {
                 foreach (var item in Banco.fases)
                 {
                     if (item.fase == _fase.fase)
                     {
                         item.estrela1 = _fase.estrela1;
                         item.estrela2 = _fase.estrela2;
                         item.estrela3 = _fase.estrela3;
                         if (item.tempo > _fase.tempo || item.tempo < 0)
                         {
                             item.tempo = _fase.tempo;
                         }
                         achou = true;
                         
                     }
					if (item.fase == proximafase)
					{
						item.aberta = true;

					}
                 }
                 if (!achou)
                 {
                     Banco.fases.Add(_fase);
                 }
                 Banco.Save();
           
             }
             catch { Debug.Log("errão"); }

         }
         else
         {
             if (!_vence)
             {
                 Tempo.text = String.Format("{0:0.00}", temp);
             }
         }
 
	}

    public static void DoChooseLevels()
    {
        Time.timeScale = 1;
        Application.LoadLevel(0);
    }

    public static void DoReplay()
    {
        Time.timeScale = 1;
        Application.LoadLevel(Application.loadedLevel);
        
    }

    public static void DoNextLevel()
    {
        Time.timeScale = 1;
        Application.LoadLevel("Mapa_Fases");
  
    }
}
