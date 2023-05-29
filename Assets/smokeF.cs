using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smokeF : MonoBehaviour
{
    public GameObject self;
            
    public ParticleSystem particles;
    public float duration = 2f; // duration in seconds to change color
    private float timer = 0f;
    private int stcl=0;

    void Start()
    {
        Invoke("startclose",3);
        Invoke("close",5);
    }

    public void startclose()
    {
        stcl=1;
    }

    public void close()
    {
        Destroy(gameObject);
    }

    void Update()
    { 
        if (stcl==1)
        {
            timer += Time.deltaTime/20;
            if (timer <= duration)
            {
                float t = timer / duration; // t is a value between 0 and 1 based on the elapsed time
                var main = particles.main;
                main.startColor = Color.Lerp(main.startColor.color, Color.clear, t); // change the color of the particles using a linear interpolation between red and green
            }
        }
    }
}