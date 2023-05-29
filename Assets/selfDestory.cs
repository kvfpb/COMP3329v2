using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestory : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GameObject[] gos2;
        gos2 = GameObject.FindGameObjectsWithTag("endGame");  
        if(gos2.Length >= 1)
        {
            Invoke("des",3);
        }
    }
    void des()
    {
        Destroy(gameObject);
    }
}
