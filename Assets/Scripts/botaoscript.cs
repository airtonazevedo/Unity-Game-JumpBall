using UnityEngine;
using System.Collections;

public class botaoscript : MonoBehaviour {

	// Use this for initialization
    bool entrou;
	void Start () {
        entrou = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        // verifica com quem está tendo colisão
        if (collision.collider.CompareTag("Bola"))
        {
			collision.gameObject.rigidbody2D.velocity = Vector2.up * 4.5f;
            Sprite tex = Resources.Load("BotaoAmareloF", typeof(Sprite)) as Sprite;

            
            this.GetComponent<SpriteRenderer>().sprite = tex;
            this.collider2D.enabled = false;
            if (entrou)
            {
                entrou = false;
                //troca imagem
                GameObject[] GameObjects = (FindObjectsOfType<GameObject>() as GameObject[]);
                foreach (GameObject PecaAmarela in GameObjects)
                {
                    if (PecaAmarela.CompareTag("BotaoAmarelo"))
                    {
                        PecaAmarela.rigidbody2D.isKinematic = false;
                        PecaAmarela.collider2D.isTrigger = true;
                    }
                    if (PecaAmarela.name == "Fumaca")
                    {
                        PecaAmarela.particleSystem.Emit(1);

                    }
                }
            }

        }
    }
}
