using UnityEngine;
using System.Collections;

public class Teste : MonoBehaviour {
    public GameObject Bola;
    public Camera cam;
    private bool _segurabotaol, _segurabotaod;
    float _velocidade = 2.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        playteclado();

        cam.transform.position = new Vector3(Bola.transform.position.x, Bola.transform.position.y, -10);
        
	}


    void playteclado()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _segurabotaol = true;
            _segurabotaod = false;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _segurabotaod = true;
            _segurabotaol = false;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _segurabotaol = false;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            _segurabotaod = false;
        }
        mover();
    }

    void mover()
    {
        if (_segurabotaod)
        {
            Bola.transform.Translate(Bola.transform.right * Time.deltaTime * _velocidade);
        }
        if (_segurabotaol)
        {
            Bola.transform.Translate(Bola.transform.right * Time.deltaTime * _velocidade * (-1));
        }
    }

    void AguaControle()
    {
        float _forca = 1000f;

       Bola.rigidbody2D.AddForce(Vector2.up * _forca);
       
    }
}
