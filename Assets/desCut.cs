using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desCut : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GameObject[] gos2;
        gos2 = GameObject.FindGameObjectsWithTag("cutscene");  
        if(gos2.Length == 2)
        {
            Invoke("des",3);
        }
    }
    void des()
    {
        Destroy(gameObject);
    }
}
