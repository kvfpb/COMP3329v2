using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tranTest : MonoBehaviour
{
    public float fadeDuration = 10.0f; // How long the object should take to fade out in seconds
    private float fadeTimer = 0.0f; // Timer to keep track of how long the object has been fading
    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        material = renderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        // Increment the timer
        fadeTimer += Time.deltaTime;
        
        // Calculate the new alpha value based on the elapsed time and fade duration
        float alpha = 1.0f - Mathf.Clamp01(fadeTimer / fadeDuration);
        
        // Set the alpha value of the material color
        Color color = material.color;
        color.a = alpha;
        material.color = color;
        
        // Destroy the object when it's fully faded out
        if (alpha <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
