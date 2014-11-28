
#if UNITY_EDITOR

using UnityEngine;
using System.Collections;
using UnityEditor;
[ExecuteInEditMode]

public class EditorGrid : MonoBehaviour
{
   

    //public int id = 0;
    public float cell_size = 0.3f; // = larghezza/altezza delle celle
    private float x, y, z;

    void Start()
    {
        x = 0f;
        y = 0f;
        z = 0f;

    }

    void Update()
    {
        
         if (!EditorApplication.isPlaying)
        {
            z = this.transform.position.z;

            x = Mathf.Round(this.transform.position.x / cell_size) * cell_size;
            y = Mathf.Round(this.transform.position.y / cell_size) * cell_size;

            this.transform.position = new Vector3(x, y, z);
       /*
            if (id == 0)
            {

            }
            if (id == 1)
            {
                if (y != this.transform.position.y)
                {

                    y = Mathf.Round(this.transform.position.y / cell_size) * cell_size + cell_size / 2;

                }
                x = Mathf.Round(this.transform.position.x / cell_size) * cell_size;

                this.transform.position = new Vector3(x, y, z);
            }
            if (id == 2)
            {
                if (x != this.transform.position.x)
                {
                    x = Mathf.Round(this.transform.position.x / cell_size) * cell_size + cell_size / 2;
                }
                y = Mathf.Round(this.transform.position.y / cell_size) * cell_size;

                this.transform.position = new Vector3(x, y, z);

            }
            if (id == 3)
            {
                if (y != this.transform.position.y)
                {
                    y = Mathf.Round(this.transform.position.y / cell_size) * cell_size + cell_size / 2;
                }
                if (x != this.transform.position.x)
                {
                    x = Mathf.Round(this.transform.position.x / cell_size) * cell_size + cell_size / 2;
                }

                this.transform.position = new Vector3(x, y, z);
            }
            if (gameObject.tag == "Andador")
            {
              //  ((BoxCollider2D)gameObject.collider2D).size = new Vector2(30, 30);
                Debug.Log(gameObject.tag);
            }
             */
        }


    }

    
}
#endif
