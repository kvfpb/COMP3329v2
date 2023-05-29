using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gasdamage : MonoBehaviour //#190
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("close",28);
    }

    public void close()
    {
        Destroy(gameObject);
        // gameObject.active=false;
    }
}
