﻿using UnityEngine;
using System.Collections;

public class EscolherPersonagens : MonoBehaviour {

	// Use this for initialization
    public SpriteRenderer  Personagem;
    Sprite tex;
 	void Start () {
      
       

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel(0);
        }
        
       

    }

    void voltar()
    {
        Application.LoadLevel(0);
    }

}
