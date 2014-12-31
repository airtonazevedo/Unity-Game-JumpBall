using UnityEngine;
using System.Collections;

public class FasesPanel : MonoBehaviour {

    public GameObject Tempo;
    public GameObject Fase;
    public GameObject Estrela1;
    public GameObject Estrela2;
    public GameObject Estrela3;

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	   if(Input.GetMouseButtonDown(0)){
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);
        Debug.Log("mouse pos "+mousePosition.x+" y "+mousePosition.y+" ");
        if (hitCollider)
        {
            //selectorSprite.transform.position.x = hitCollider.transform.position.x;
            //selectorSprite.transform.position.y = hitCollider.transform.position.y;
            Debug.Log("Hit " + hitCollider.transform.name + " x" + hitCollider.transform.position.x + " y " + hitCollider.transform.position.y);
        }
    }

	}
}
