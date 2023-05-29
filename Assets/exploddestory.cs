using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exploddestory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("close",5);
    }

    public void close()
    {
        Destroy(gameObject);
        // gameObject.active=false;
    }
}
