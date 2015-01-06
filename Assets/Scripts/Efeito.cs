using UnityEngine;
using System.Collections;

public class Efeito : MonoBehaviour {

    public bool start = true;

    public float minimum = 0;
    public float maximum = 1;
    public float duration = 0.5f;
    private float startTime;

    void OnEnable()
    {
        minimum = 0;
        maximum = 1;
       startTime = Time.time;
    }
   
    void Update()
    {
        if (start)
        {
            float t = (Time.time - startTime) / duration;
            transform.localScale = new Vector3(Mathf.SmoothStep(minimum, maximum, t), Mathf.SmoothStep(minimum, maximum, t), 1);
       
        }
    }
}
