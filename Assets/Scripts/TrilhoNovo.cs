using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[ExecuteInEditMode]
public class TrilhoNovo : MonoBehaviour {

    public float Velocidade = 2;
    public GameObject Ponto;
    public bool MostrarLinha = true;
    public List<GameObject> pontos;
    public bool Circular = false;
	// Use this for initialization
    private Vector2 direcao;
    private int k = 0;
    private int sentido = 1;

    void Awake()
    {

        #if UNITY_EDITOR
        if (!UnityEditor.EditorApplication.isPlaying)
        {
          if (pontos.Count < 2)
            {
                 pontos = new List<GameObject>();
                Comeca2();
            }
       
        }
#endif
    }

    void Start()
    {
   //     pontos = new List<GameObject>();


#if UNITY_EDITOR

        if (UnityEditor.EditorApplication.isPlaying)
        {
            Comeca();
        }
#else
        Comeca();
#endif

}
    void OnTriggerExit2D(Collider2D colisor)
    {
         for (int i = 0; i < pontos.Count; i++)
        {
            if (pontos[i].Equals(colisor.gameObject))
            {
         //       this.transform.position = pontos[i].transform.position;
                if (i == 0)
                {
                    sentido = 1;
                }

                if (pontos.Count - 1 == i)
                {
                    if (Circular)
                    {
                        direcao = pontos[i].transform.position - pontos[0].transform.position;
                    }
                    else
                    {
                        sentido = -1;

                    }
                }
                else
                {
                    if (sentido == -1)
                    {
                        direcao = pontos[i-1].transform.position - pontos[i].transform.position;
                
                    }
                    else
                    {
                        direcao = pontos[i].transform.position - pontos[i + 1].transform.position;
                    }
                  
                }
                direcao.Normalize();
                break;
            }
        }
    }
	// Update is called once per frame

    void Comeca2()
    {
        Object p1 = Instantiate(Ponto, new Vector3(this.transform.position.x, this.transform.position.y, 3), Quaternion.identity);
        Object p2 = Instantiate(Ponto, new Vector3(this.transform.position.x + 0.6f, this.transform.position.y, 3), Quaternion.identity);

        pontos.Add((GameObject)p1);
        pontos.Add((GameObject)p2);
    }

    void Comeca()
    {
        this.renderer.enabled = MostrarLinha;
        for (int i = 0; i < pontos.Count; i++)
        {
            this.GetComponent<LineRenderer>().SetPosition(i, pontos[i].transform.position);

            pontos[i].renderer.enabled = false;
        }
     

        this.transform.position = pontos[0].transform.position;
      //  Move.transform.position = pontos[0].transform.position;
       // Move.transform.parent = this.transform;
        direcao = pontos[0].transform.position - pontos[1].transform.position;
        direcao.Normalize();
    }

	void Update () {

      
#if UNITY_EDITOR

        if (UnityEditor.EditorApplication.isPlaying)
        {
            this.renderer.enabled = MostrarLinha;
       
            this.rigidbody2D.velocity = direcao * Velocidade * sentido * -1;
        }
        else
        {
            this.transform.position = pontos[0].transform.position;
    
            if (Circular)
            {
                this.GetComponent<LineRenderer>().SetVertexCount(pontos.Count + 1);
                this.GetComponent<LineRenderer>().SetPosition(pontos.Count, pontos[0].transform.position);

            }
            else
            {
                this.GetComponent<LineRenderer>().SetVertexCount(pontos.Count);

            }

            for (int i = 0; i < pontos.Count; i++)
            {

                this.GetComponent<LineRenderer>().SetPosition(i, pontos[i].transform.position);
         
            }
        }

#else
     this.rigidbody2D.velocity = direcao * Velocidade * sentido * -1;
#endif
      
}


    public void AddPonto()
    {
        Object p = Instantiate(Ponto, new Vector3(pontos[pontos.Count - 1].transform.position.x + 0.6f, pontos[pontos.Count - 1].transform.position.y, 3), Quaternion.identity);
        pontos.Add((GameObject)p as GameObject);

    }
}
