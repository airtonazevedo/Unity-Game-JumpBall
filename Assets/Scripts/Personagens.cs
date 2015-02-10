using UnityEngine;
using System.Collections;
using Assets.Plugins.SmartLevelsMap.Scripts;

public class Personagens : MonoBehaviour {

	// Use this for initialization
    public GameObject Bola;
    public Texture[] btnTexture;
    public SpriteRenderer Personagem;
    public GameObject texo;
    public float x1;
    public float y1;
    public float h1;
    public float w1;

    Sprite tex;
    void OnGUI()
    {
        string[] nome = new string[18];
        float h, w, x, y;

        h = Screen.height * h1;
        w = h + w1 * Screen.height;

      
        y = Screen.height / 2 - w / 2 + y1 * Screen.height;

        for (int i = 0; i < 18; i++)
        {
            nome[i] = "B" + (i+1).ToString();
           // Debug.Log(nome[i]);
        }

        for (int i = 0; i < 6; i++)
        {
            x = (Screen.width / 7 * (i+1)) - w/2;

            if (GUI.Button(new Rect(x, y, w, h), btnTexture[i])) { 
              //  transform.parent.SendMessage(nome[i]);
                if (Banco.TotalDeEstrelas() >= i * 3)
                {
                    tex = Resources.Load((PlayerPrefs.GetInt("bola") + 1).ToString(), typeof(Sprite)) as Sprite;
                    PlayerPrefs.SetInt("bola", i);
                    texo.GetComponent<TextMesh>().text = "";
                }
                else 
                {
                    tex = Resources.Load("Tranca", typeof(Sprite)) as Sprite;
                    texo.GetComponent<TextMesh>().text = "Requer " + (i * 3).ToString() + " estrelas";
                }
                Personagem.sprite = tex;
                  
        }

        }
        y = Screen.height / 2 - w / 2 + (y1+0.175f) * Screen.height;

        for (int i = 6; i < 12; i++)
        {
            x = (Screen.width / 7 * (i + 1 -6)) - w / 2;

            if (GUI.Button(new Rect(x, y, w, h), btnTexture[i])){
              //  transform.parent.SendMessage(nome[i]);
                if (Banco.TotalDeEstrelas() >= i * 3)
                {
                    tex = Resources.Load((PlayerPrefs.GetInt("bola") + 1).ToString(), typeof(Sprite)) as Sprite;
                    PlayerPrefs.SetInt("bola", i);
                    texo.GetComponent<TextMesh>().text = "";
                }
                else
                {
                    tex = Resources.Load("Tranca", typeof(Sprite)) as Sprite;
                    texo.GetComponent<TextMesh>().text = "Requer " + (i * 3).ToString() + " estrelas";
                }
                Personagem.sprite = tex;
            }

        }


        y = Screen.height / 2 - w / 2 + (y1 + 0.35f) *Screen.height;

        for (int i = 12; i < 18; i++)
        {
            x = (Screen.width / 7 * (i + 1 - 12)) - w / 2;

            if (GUI.Button(new Rect(x, y, w, h), btnTexture[i])) {
                if (Banco.TotalDeEstrelas() >= i * 3)
                {
                    tex = Resources.Load((PlayerPrefs.GetInt("bola") + 1).ToString(), typeof(Sprite)) as Sprite;
                    PlayerPrefs.SetInt("bola", i);
                    texo.GetComponent<TextMesh>().text = "";
             
                }
                else
                {
                    tex = Resources.Load("Tranca", typeof(Sprite)) as Sprite;
                    texo.GetComponent<TextMesh>().text = "Requer " + (i * 3).ToString() + " estrelas";
                }
                Personagem.sprite = tex;
        }

        }
    }

    void Reiniciar()
    {
        Bola.transform.position = new Vector3(-11.0f, -1.5f, 0);
      

    }
    void PecasColisao()
    {
        //        Debug.Log(Bola.transform.position.x.ToString());
        Bola.rigidbody2D.velocity = Vector2.up * 4.5f;
    }


	void Start () {
        tex = Resources.Load((PlayerPrefs.GetInt("bola") + 1).ToString(), typeof(Sprite)) as Sprite;
                   
	}
	
	// Update is called once per frame
	void Update ()
    {
        Bola.GetComponent<SpriteRenderer>().sprite = tex;
        Bola.transform.rigidbody2D.angularVelocity = -300;
        Bola.transform.rigidbody2D.velocity = Vector2.right * 2.5f + Bola.transform.rigidbody2D.velocity.y * Vector2.up;
           
    }
}
