using UnityEngine;
using System.Collections;
using Assets.Plugins.SmartLevelsMap.Scripts;

public class HomeScript : MonoBehaviour {

    public GameObject Bolao;

    private bool chave;
    private float _velocidade,tempo = 0, tempo2 = 0;
    private Vector3 _bolaini;
    private GameObject Bola;

	// Use this for initialization
    void Start()
    {
        chave = false;
        Time.timeScale = 1;

        _bolaini = Vector3.zero;
        _velocidade = 2.5f;
        _bolaini = Bolao.transform.position;

        Bola = GameObject.Instantiate(Bolao) as GameObject;
        Bola.transform.position = _bolaini;
        Bola.collider2D.isTrigger = true;
        Bola.rigidbody2D.gravityScale = 0;
        Bola.transform.parent = transform;
        Banco.Load();

        if (!PlayerPrefs.HasKey("Vidas")) 
        {
            PlayerPrefs.SetInt("Vidas", 50);
        }
        #if (UNITY_EDITOR || UNITY_ANDROID || UNITY_IPHONE)

        UnityEngine.Advertisements.Advertisement.Initialize("18062");
        #endif
    }
	
	// Update is called once per frame
	void Update () {
        tempo = Time.time;
        if (tempo > 3 + tempo2)
        {
            Bola.collider2D.isTrigger = false;
            Bola.rigidbody2D.gravityScale = 1;

        }
       // Debug.Log("lol");
        Bola.transform.Translate(Bola.transform.right * Time.deltaTime * _velocidade);

        if(Bola.transform.position.x>0 && !chave)
        {
            chave = true;
            GameObject[] GameObjects = (FindObjectsOfType<GameObject>() as GameObject[]);
            Debug.Log("xaxa");
            foreach (GameObject PecaAmarela in GameObjects)
            {
                if (PecaAmarela.tag == "Respawn")
                {
                    PecaAmarela.rigidbody2D.isKinematic = true;
                }

            }
        }
        if(   Input.GetKeyDown(KeyCode.Escape) )
        {
            Application.Quit();
        }

	}

    void Reiniciar()
    {

        

        Destroy(Bola);
        tempo2 = Time.time;
        Bola = GameObject.Instantiate(Bolao) as GameObject;
        Bola.transform.position = _bolaini;
        Bola.collider2D.isTrigger = true;
        Bola.rigidbody2D.gravityScale = 0;

        Bola.transform.parent = transform;
    }

    void comecar()
    {
        AutoFade.LoadLevel("Mapa_Fases", 0.2f, 0.2f, Color.black);
   //     Application.LoadLevel("Mapa_Fases");
    }

    void EscolherPersonagem()
    {
        Application.LoadLevel("Personagens");
    }

    void Configuracoes()
    {
        Application.LoadLevel("Configuracao");
        Banco.Limpar();
     }
    

}
