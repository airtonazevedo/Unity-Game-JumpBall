using UnityEngine;
using System.Collections;

public class Trilho : MonoBehaviour {

    public GameObject ponto1;
    public GameObject ponto2;
    private Vector2 direcao;
    public int sentido = 1;
    public float velocidade = 2;

	// Use this for initialization
	void Start () {
     this.GetComponent<LineRenderer>().SetPosition(0,ponto1.transform.position);
     this.GetComponent<LineRenderer>().SetPosition(1, ponto2.transform.position);
     ponto1.renderer.enabled = false;
     ponto2.renderer.enabled = false;
     this.renderer.enabled = false;

     direcao = ponto1.transform.position - ponto2.transform.position;
     direcao.Normalize();
    }
	
	// Update is called once per frame
	void Update () {
        this.rigidbody2D.velocity = direcao * velocidade * sentido;

       
	}
    void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.CompareTag("Trilhos"))
        {
            sentido *= -1;
        }

    }
}
