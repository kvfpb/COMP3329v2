using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addEndCam : MonoBehaviour
{
    public GameObject endcam;
    // Update is called once per frame
    void Update()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("endGame"); 
        if(gos.Length == 0)
        {
        }
        else
        {
            Rigidbody rb = Instantiate(endcam, transform.position, transform.rotation).GetComponent<Rigidbody>(); 
            
        }
    }
}
