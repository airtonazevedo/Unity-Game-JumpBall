using UnityEngine;
using System.Collections;

public class EscolherPersonagens : MonoBehaviour {

	// Use this for initialization
    public SpriteRenderer  Personagem;
    Sprite tex;
 	void Start () {
      
       

    }
	
	// Update is called once per frame
	void Update () {

        Sprite spt = Resources.Load("Imagem", typeof(Sprite)) as Sprite;
        


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel(0);
        }
        
        tex = Resources.Load((PlayerPrefs.GetInt("bola") + 1).ToString(), typeof(Sprite)) as Sprite;
       

        Personagem.transform.Rotate(0, 0, -100 * Time.deltaTime);

    }

    void voltar()
    {
        Application.LoadLevel(0);
    }

}
