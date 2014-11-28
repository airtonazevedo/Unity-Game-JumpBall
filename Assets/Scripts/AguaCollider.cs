using UnityEngine;
using System.Collections;

public class AguaCollider : MonoBehaviour {

	// Use this for initialization
    void OnTriggerStay2D(Collider2D colisao)
    {
        transform.parent.SendMessage("AguaControle");
    }
    
   
}
