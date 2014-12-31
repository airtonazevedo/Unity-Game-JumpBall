using UnityEngine;
using System.Collections;

public class PecaAnda : MonoBehaviour {

    public float velocidade = 2;
    int sentido = 1;
    public bool vertical;
	// Use this for initialization
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Andador"))
        {

            sentido *= -1;
            if (vertical)
            {
                this.rigidbody2D.velocity = Vector2.up * velocidade * sentido;

            }
            else
            {
                this.rigidbody2D.velocity = Vector2.right * velocidade * sentido;
            }
        }

    }

    void Start()
    {
        if (vertical)
        {
            this.rigidbody2D.velocity = Vector2.up * velocidade * sentido;

        }
        else
        {
            this.rigidbody2D.velocity = Vector2.right * velocidade * sentido;
        }
    }


}
