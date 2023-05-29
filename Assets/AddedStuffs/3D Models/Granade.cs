using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Granade : MonoBehaviourPunCallbacks
{
    // public float delay = 3f;
    public float radius =  3f;
    public float explosionForce = 700f ;
    public int done=0;

    public GameObject explosionEffect;
    // public startButton startButton;

    // float countdown;
    bool hasExploded = false;
    // Start is called before the first frame update
    void Start()
    {
        // print(gameObject.name);
    }

    private void OnCollisionEnter(Collision collision){
        Explode();
        hasExploded=true;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasExploded==true)
        {
            Destroy(gameObject);            
        }
    }

    // bug – explode effect retain
    public void EffectRemove()
    {
        Destroy(explosionEffect);
    }

    void Explode()
    {
        Invoke("EffectRemove",5);
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearbyObject in collidersToMove)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if(rb!=null)    
            {
                rb.AddExplosionForce(explosionForce, transform.position, radius);
                if(rb.ToString()=="Player (UnityEngine.Rigidbody)")
                {
                    DestructibleP destP = nearbyObject.GetComponent<DestructibleP>();
                    if(destP!=null && gameObject.name=="player1" && done==0) // not throw by camman
                    {
                        destP.killbyR1();
                        done=1;
                    }
                    if(destP!=null && gameObject.name=="player2" && done==0) // not throw by camman
                    {
                        destP.killbyR2();
                        done=1;
                    }
                }
            }
        }

        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearbyObject in collidersToDestroy)
        {
            Destructible dest = nearbyObject.GetComponent<Destructible>();
            if(dest!=null)
            {
                print("0");
                dest.Destroy();
            }
        }

        // Remove grenade
        Destroy(gameObject);
    }    
}
