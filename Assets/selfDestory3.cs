using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestory3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("des",3);
    }

    void des()
    {
        Destroy(gameObject);
    }
}
