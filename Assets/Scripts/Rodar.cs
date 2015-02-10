 using UnityEngine;
using System.Collections;

public class Rodar : MonoBehaviour {


    public float velocidade = 15;
	// Update is called once per frame
	void FixedUpdate () {
        this.transform.Rotate(0,0,velocidade);
  }
}
