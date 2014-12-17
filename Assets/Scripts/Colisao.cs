using UnityEngine;
using System.Collections;

public class Colisao : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        // verifica com quem está tendo colisão
        if (collision.collider.CompareTag("Finish")) {

            transform.parent.SendMessage("Reiniciar");
        }
        if (collision.collider.CompareTag("Player"))
        {

            transform.parent.SendMessage("Vencer");   
        }
        if (collision.collider.CompareTag("Player2"))
        {

            transform.parent.SendMessage("Vencer2");
        }
        if (collision.collider.CompareTag("Bola"))
        {
             transform.parent.SendMessage("Reiniciar");
        }
        if (collision.collider.CompareTag("Pecas"))
        {
            foreach (var item in collision.contacts)
            {
                if (item.normal.x == 0)
                {

                    transform.parent.SendMessage("PecasColisao");
                }
                else
                {
                    if (item.normal.y > 0.7f)
                    {
                        transform.parent.SendMessage("PecasColisao");
                    }
                }
            }
        }

        if (collision.collider.CompareTag("Pecacai"))
        {
            foreach (var item in collision.contacts)
            {
                if (item.normal.x == 0)
                {
                    collision.gameObject.rigidbody2D.gravityScale = 1;
                    collision.gameObject.collider2D.isTrigger = true;
                    transform.parent.SendMessage("PecasColisao");
                }
                else
                {
                    if (item.normal.y > 0.7f)
                    {
                    collision.gameObject.rigidbody2D.gravityScale = 1;
                    collision.gameObject.collider2D.isTrigger = true;
                        transform.parent.SendMessage("PecasColisao");
                    }
                }
            }

        }
        if (collision.collider.CompareTag("Up"))
        {
            foreach (var item in collision.contacts)
            {
                if (item.normal.x == 0)
                {

                    transform.parent.SendMessage("UpColisao");
                }
                else
                {
                    if (item.normal.y > 0.7f)
                    {
                        transform.parent.SendMessage("UpColisao");
                    }
                }
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D colisor) 
    {
        if (colisor.CompareTag("Finish"))
        {
              transform.parent.SendMessage("Reiniciar");
        }
        if (colisor.CompareTag("Agua"))
        {
            Debug.Log("lalalala");
        }
        if (colisor.gameObject.CompareTag("Estrela"))
        {
            colisor.gameObject.collider2D.enabled = false;
            colisor.gameObject.renderer.enabled = false;
            transform.parent.SendMessage("Estrela1");
        }
        if (colisor.CompareTag("Estrela2"))
        {
            colisor.gameObject.collider2D.enabled = false;
            colisor.gameObject.renderer.enabled = false;
            transform.parent.SendMessage("Estrela2");
        }
        if (colisor.CompareTag("Estrela3"))
        {
            colisor.gameObject.collider2D.enabled = false;
            colisor.gameObject.renderer.enabled = false;
            transform.parent.SendMessage("Estrela3");
        }

    }

	// Update is called once per frame
	void Update () {
	    
	}
}
