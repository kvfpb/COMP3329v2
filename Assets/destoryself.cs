using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destoryself : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ds",5);
    }
    private void ds()
    {
        Destroy(gameObject);
    }
}
