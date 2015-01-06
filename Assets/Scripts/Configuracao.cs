using UnityEngine;
using System.Collections;
using Assets.Plugins.SmartLevelsMap.Scripts;

public class Configuracao : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Limpar()
    {
        PlayerPrefs.SetInt("Vidas", 10);
        Banco.Limpar();
    }


    void Zerar()
    {
        Banco.Zerar();
    }


    void Anuncio()
    {
     //Videozao
    }


    void Volta()
    {
        Application.LoadLevel(0);
    }
}
