using UnityEngine;
using System.Collections;

public class StarTempo : MonoBehaviour {

    public static bool v;
    public float tempo=10;
    public GameObject smoke;
    
	// Use this for initialization
	void Start () {
        v = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void FixedUpdate()
    {

        gameObject.transform.localScale = new Vector3(0.5f + 2f * (tempo - GameplayScript.temp) / tempo, 0.5f + 2 * (tempo - GameplayScript.temp) / tempo, 0);

        if (v && gameObject.transform.localScale.x < 0.5f)
        {
            v = false;

            smoke.particleSystem.Emit(1);
            //Time.timeScale = 0;
            gameObject.renderer.enabled = false;
            gameObject.collider2D.enabled = false;
        }
        
       
        

    }
}
