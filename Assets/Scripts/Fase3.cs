using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Fase3 : MonoBehaviour {
    public GameObject[] peca;
    public GUIText tempo;


    private List<GameObject> pecas = new List<GameObject>();
    private Vector3 v;
    private int i = 0;

    void Start()
    {
        v = Camera.main.ViewportToWorldPoint(new Vector3(0.12f, 0.5f, 1));
        v.z = -1;
        PosicionarPecas();

        tempo.transform.position = new Vector3(0.9f, 0.95f, 0);
        tempo.fontSize = Convert.ToInt32(Screen.height * 0.05f);


    }

    // Update is called once per frame
    void Update()
    {

    }

    void PosicionarPecas()
    {

        BotarPecas(0, 0, 4, v, 0);
        BotarPecas(2, 0, 5, pecas[i - 1].transform.position, 0);
        BotarPecas(2, 0, 6, pecas[i - 1].transform.position, 0);
        BotarPecas(2, 0, 5, pecas[i - 1].transform.position, 180);
        BotarPecas(2, 0, 4, pecas[i - 1].transform.position, 0);
        BotarPecas(2, 0, 5, pecas[i - 1].transform.position, 0);
        BotarPecas(2, 0, 6, pecas[i - 1].transform.position, 0);
        BotarPecas(2, 0, 5, pecas[i - 1].transform.position, 180);
        BotarPecas(2, 0, 4, pecas[i - 1].transform.position, 0);
        BotarPecas(2, 0, 5, pecas[i - 1].transform.position, 0);
        BotarPecas(2, 0, 6, pecas[i - 1].transform.position, 0);
        //ganha
        BotarPecas(0.5f, 1, 10, pecas[i - 1].transform.position, 0);
        //paredes
        BotarPecas(-4, 0, 11, v, 0);
        BotarPecas(25, 0, 11, v, 0);
        BotarPecas(10, 9, 11, v, 90);
        BotarPecas(10, -9, 11, v, 90);
         
    }
    void BotarPecas(float x, float y, int cod, Vector3 w, int rot)
    {

        w.x += 0.6f * x;
        w.y += 0.6f * y;
        pecas.Add(GameObject.Instantiate(peca[cod]) as GameObject);
        pecas[i].transform.parent = transform;
        pecas[i].transform.position = w;
        pecas[i].transform.Rotate(0, 0, rot);
        i++;

    }

   
}
