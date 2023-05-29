using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raise : MonoBehaviour
{
    public Transform target;
    public float t;
    // public Rigidbody rb;
    // Update is called once per frame
    void FixedUpdate()
    {
        // rb.AddForce(0,200f*Time.deltaTime,0);
        Vector3 a = transform.position;
        Vector3 b = target.position;
        transform.position = Vector3.Lerp(a,b,t);
        // transform.position = Vector3.Lerp(a,b,t) * Time.deltaTime;
    }
}
