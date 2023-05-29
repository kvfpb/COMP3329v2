using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class granadeG : MonoBehaviourPunCallbacks
{
    // public float delay = 3f;
    public float radius =  3f;
    public float explosionForce = 700f ;
    private float testvx = 0f ;
    private float testvz = 0f ;

    public GameObject explosionEffect0;
    public GameObject explosionEffect;
    public GameObject damageball;
    public Transform Synchronize; //#189
    Rigidbody rb;

    // float countdown;
    bool hasExploded = false;
    bool hasExploded2 = false;
    // Start is called before the first frame update
    // void Start()
    // {
    //     countdown = delay;
    // }


    private void OnCollisionEnter(Collision collision){
        rb = GetComponent<Rigidbody>();
        hasExploded=true;
    }

    // Update is called once per frame
    void Update()
    {
        // print(transform.position);
        // if(hasExploded==true && rb.velocity.x==0 && rb.velocity.y==0 && rb.velocity.z==0 && hasExploded2==false)
        if(hasExploded==true && hasExploded2==false)
        {
            Explode();
            hasExploded2=true;
        }
        if(hasExploded==true && rb.velocity.x>0f && hasExploded2==false)
        {
            testvx=rb.velocity.x-0.1f;
            if(testvx<=0f)
            {
                rb.velocity = new Vector3(0f, rb.velocity.y, rb.velocity.z);
            }
            else
            {
                rb.velocity = new Vector3(testvx, rb.velocity.y, rb.velocity.z);       
            }
        }
        if(hasExploded==true && rb.velocity.z>0f && hasExploded2==false)
        {
            testvz=rb.velocity.z-0.1f;
            if(testvz<=0f)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0f);
            }
            else
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, testvz);       
            }
        }
        if(hasExploded==true && rb.velocity.x<0f && hasExploded2==false)
        {
            testvx=rb.velocity.x+0.1f;
            if(testvx>=0f)
            {
                rb.velocity = new Vector3(0f, rb.velocity.y, rb.velocity.z);
            }
            else
            {
                rb.velocity = new Vector3(testvx, rb.velocity.y, rb.velocity.z);       
            }
        }
        if(hasExploded==true && rb.velocity.z<0f && hasExploded2==false)
        {
            testvz=rb.velocity.z+0.1f;
            if(testvz>=0f)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0f);
            }
            else
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, testvz);       
            }
        }
        if(hasExploded==true && rb.velocity.y<0.01f && rb.velocity.y>-0.01f && hasExploded2==false)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        }
        GameObject[] gosc;
        gosc = GameObject.FindGameObjectsWithTag("cutscene");
        if(gosc.Length == 2)
        {  
            CancelInvoke("gas0");
            CancelInvoke("gas1");
            CancelInvoke("gas");
            Destroy(gameObject);
		}
    }

    // bug – explode effect retain
    // public void EffectRemove()
    // {
    //     Destroy(explosionEffect);
    // }

    void Explode()
    {
        // Instantiate(explosionEffect0, transform.position+ Vector3.up * 2f, Quaternion.Euler(0f, 0f, 0f));
        Instantiate(explosionEffect0, new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z + 0.4f), Quaternion.Euler(0f, 0f, 0f));
        // GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; //#188
        Invoke("gas0",4);
        Invoke("gas1",4.5f);
        Invoke("gas",5);

        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearbyObject in collidersToMove)
        {
            
            // Add force
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if(rb!=null)    
            {
                // rb.AddExplosionForce(explosionForce, transform.position, radius);
                if(rb.ToString()=="Player (UnityEngine.Rigidbody)")
                {
                    DestructibleP destP = nearbyObject.GetComponent<DestructibleP>();
                    if(destP!=null)
                    {
                        // destP.Destroy();
                    }
                }
            }
        }   
    }

    [PunRPC] //#189
    public void tran()
    {
        Rigidbody rbt = gameObject.GetComponent<Rigidbody>(); 
        rbt.position= Synchronize.position;
    }
    
    public void gas0() //#193
    {
        GameObject[] gos; //#189
        gos = GameObject.FindGameObjectsWithTag("Player"); //#189
        if(gameObject.name==gos[0].name||gameObject.name==gos[1].name) //#189
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }
    public void gas1() //#193
    {
        GameObject[] gos; //#189
        gos = GameObject.FindGameObjectsWithTag("Player"); //#189
        if(gameObject.name==gos[0].name||gameObject.name==gos[1].name) //#189
        {
            photonView.RPC("tran",RpcTarget.All);
        }
    }

    public void gas()
    {
        // explosionEffect0.active=false;
        Vector3 newPosition1 = transform.position + new Vector3(1f, 1f, 0f);
        Vector3 newPosition2 = transform.position + new Vector3(-1f, -1f, 0f);
        Vector3 newPosition3 = transform.position + new Vector3(0f, -1f, 1f);
        Vector3 newPosition4 = transform.position + new Vector3(0f, 1f, -1f);
        Quaternion newRotation1 = transform.rotation * Quaternion.Euler(90f, 0f, 0f);
        Quaternion newRotation2 = transform.rotation * Quaternion.Euler(-90f, 0f, 0f);
        Quaternion newRotation3 = transform.rotation * Quaternion.Euler(180f, 0f, 0f);
        Quaternion newRotation4 = transform.rotation * Quaternion.Euler(-180f, 0f, 0f);
        Instantiate(explosionEffect, newPosition1, newRotation1);
        Instantiate(explosionEffect, newPosition2, newRotation2);
        Instantiate(explosionEffect, newPosition3, newRotation3);
        Instantiate(explosionEffect, newPosition4, newRotation4);
        Rigidbody rbg = Instantiate(damageball, transform.position+ new Vector3(0f, 3f, 0f), transform.rotation).GetComponent<Rigidbody>();
        rbg.name=gameObject.name;
        Destroy(gameObject);
    }
}
