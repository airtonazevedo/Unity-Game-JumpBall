using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {

    float y, velocidade;
    bool intensidade;
	// Use this for initialization
	void Start () {
        y = gameObject.transform.position.y;
	    
	}

    void Update()
    {
        if (intensidade)
        {
            velocidade = 0.25f;
        }
        else
        {
            velocidade = -0.5f;
        }
        if (gameObject.transform.position.y > y + 0.1f)
        {
            intensidade = false;
        }
        if (gameObject.transform.position.y < y)
        {
            intensidade = true;
        }
        gameObject.transform.Translate(gameObject.transform.up * velocidade * Time.deltaTime);
           

    }
	
	// Update is called once per frame
	
}
