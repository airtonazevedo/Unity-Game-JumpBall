using UnityEngine;
using System.Collections;

public class AguaCollider : MonoBehaviour {

	// Use this for initialization
    void OnTriggerStay2D(Collider2D colisao)
    {
        if (colisao.CompareTag("Agua"))
        {
            Debug.Log("xaxsa");
            this.rigidbody2D.AddForce(Vector2.up * 200);
        }
    }
    
   
}
