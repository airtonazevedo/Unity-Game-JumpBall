using UnityEngine;
using System.Collections;
using Assets.Plugins.SmartLevelsMap.Scripts;

public class Ganhored : MonoBehaviour {

	// Use this for initialization
    public string NomeDaFase = "Fase";
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bola"))
        {
            try
            {
                foreach (var item in Banco.fases)
                {

                    if (item.fase == NomeDaFase)
                    {
                        item.aberta = true;

                    }
                }

                Banco.Save();
            }
            catch { Debug.Log("Errao"); }
        }
    }

     public static void DoChooseLevels()
    {
        Time.timeScale = 1;
        Application.LoadLevel("Mapa_Fases");
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
