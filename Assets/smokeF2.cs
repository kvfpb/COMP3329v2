using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smokeF2 : MonoBehaviour
{
    public GameObject self;
            
    public smokeF2 main;
    private ParticleSystem particles;
    private Material particleMaterial;
    public float duration = 5f; // duration in seconds to change color
    private float timer = 0f;
    private int stcl=0;

    // public Vector3 targetScale = Vector3.one * 2f; // Target scale to reach
    // private Vector3 startScale; // Starting scale of the object
    // public float duration2 = 5f; // Total duration of the scaling animation
    // private float timer2 = 0f; // Timer to keep track of the animation progress

    void Start()
    {
        Invoke("startclose",25);
        Invoke("close",30);
        particles = GetComponent<ParticleSystem>();
        particleMaterial = GetComponent<ParticleSystemRenderer>().material;
        // startScale = transform.localScale;
        
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
            timer += Time.deltaTime/30;
            if (timer <= duration)
            {
                float t = timer / duration;
                particleMaterial.color = Color.Lerp(main.particleMaterial.color, Color.clear, t);
            }
        }
    }
}
