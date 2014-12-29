
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

             
            if (this.transform.localEulerAngles.z % 90 > 45)
            {
                this.transform.Rotate(0, 0, 90 - this.transform.localEulerAngles.z % 90);
       
            }
            else if (this.transform.localEulerAngles.z % 90 < 45 && this.transform.localEulerAngles.z % 90 > 0)
            {
                this.transform.Rotate(0, 0,- this.transform.localEulerAngles.z % 90);
       
            }
            
         }


    }

    
}
#endif
