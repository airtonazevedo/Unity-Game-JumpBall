using UnityEngine;
using System.Collections;

public class Andar : MonoBehaviour
{

    public float Velocidade = 2;
    public GameObject Move;
    public GameObject[] pontos;
    public bool Circular = false;
    // Use this for initialization
    private Vector2 direcao;
    private int k = 0;
    private int sentido = 1;

    void Start()
    {
        this.GetComponent<LineRenderer>().SetVertexCount(10);
        for (int i = 0; i < pontos.Length; i++)
        {

            this.GetComponent<LineRenderer>().SetPosition(i, pontos[i].transform.position);
            pontos[i].renderer.enabled = false;

        }
        this.renderer.enabled = false;
        this.transform.position = pontos[0].transform.position;
        Move.transform.parent = this.transform;
        direcao = pontos[0].transform.position - pontos[1].transform.position;
        direcao.Normalize();
    }

    void OnTriggerEnter2D(Collider2D colisor)
    {
        for (int i = 0; i < pontos.Length; i++)
        {
            if (pontos[i].Equals(colisor.gameObject))
            {
                if (i == 0)
                {
                    sentido = 1;
                }

                if (pontos.Length - 1 == i)
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
                        direcao = pontos[i - 1].transform.position - pontos[i].transform.position;

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
    void Update()
    {
        this.rigidbody2D.velocity = direcao * Velocidade * sentido;

    }
}
