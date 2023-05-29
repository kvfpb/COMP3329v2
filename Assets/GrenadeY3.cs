using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GrenadeY3 : MonoBehaviourPunCallbacks
{
    public float radius =  9f;
    public float explosionForce = 700f ;
    private int CanExplode=0;
    public GameObject explosionEffect;
    public grenadeNumberY yellowcount;
    public GameObject RemoteGrenade;
    public GameObject setting1;
    public GameObject setting2;
    public GameObject setting3;
    public GameObject box1;
    public GameObject box2;
    public GameObject box3;
    public GameObject boxnum;
    private int throwed=0;
    private int stagec=0;
    public DestructibleP DestructibleP;
    bool hasExploded = false;
    public GameObject setting1sound;
    public GameObject setting2sound;
    public GameObject setting3sound;

    public void Awake()
    {
        hasExploded=false;
        CanExplode=0;
        throwed=0;
        box1.active=false;
        box2.active=false;
        box3.active=false;
        setting1sound.active=false;
        setting2sound.active=false;
        setting3sound.active=false;
        boxnum.active=false;
    }   
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; //#188
        if(throwed==0)
        {
            throwed=1;
            Invoke("CanExplodef1",1);
            Invoke("CanExplodef2",2);
            Invoke("CanExplodef3",3);
        }
    }
    private void ce3()
    {
        if(throwed==0)
        {
            throwed=1;
            Invoke("CanExplodef1",1);
            Invoke("CanExplodef2",2);
            Invoke("CanExplodef3",3);
        }
    }
    private void CanExplodef1()
    {
        setting1.active=false;
        setting1sound.active=true;
    }
    private void CanExplodef2()
    {
        setting2.active=false;
        setting2sound.active=true;
    }
    private void CanExplodef3()
    {
        setting3sound.active=true;
        setting3.active=false;
        CanExplode=1; 
        box1.active=true;
        box2.active=true;
        box3.active=true;
        boxnum.active=true;
    }
    public void upthrowed()
    {
        throwed=0;
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("ce3",12);
        if (Input.GetKey("3") && CanExplode==1 && DestructibleP.dead==0)
        {
            if(photonView.IsMine)
            {
                ExplodeY();
                hasExploded=true;
                yellowcount.GetComponent<grenadeNumberY>().count=" 0";
                CanExplode=0;
            }
        }
        GameObject[] gosc;
        gosc = GameObject.FindGameObjectsWithTag("cutscene");
        if(gosc.Length == 2 && stagec==0)
        {  
            hasExploded=false;
            yellowcount.GetComponent<grenadeNumberY>().count=" 1";
            CanExplode=0;
            throwed=0;
			stagec=1;
            RemoteGrenade.active=false;
            box1.active=false;
            box2.active=false;
            box3.active=false;
            boxnum.active=false;
		}
        if(gosc.Length == 0 && stagec==1)
        {  
			stagec=0;
		}
        GameObject[] gos2;
        gos2 = GameObject.FindGameObjectsWithTag("endGame");  
        if(gos2.Length >= 1)
        {
            Invoke("des",2.9f);
            CancelInvoke("ce3");
        }
    }

    public void ExplodeY()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; //#188
        photonView.RPC("explosionEf",RpcTarget.All);
        // Get nearby ojects
        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearbyObject in collidersToDestroy)
        {
            Destructible dest = nearbyObject.GetComponent<Destructible>();
            // print(nearbyObject);
            if(dest!=null)
            {
                dest.Destroy();
            }
        }

        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearbyObject in collidersToMove)
        {
            
            // Add force
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if(rb!=null)    
            {
                rb.AddExplosionForce(explosionForce, transform.position, radius);
                if(rb.ToString()=="Player (UnityEngine.Rigidbody)")
                {
                    DestructibleP destP = nearbyObject.GetComponent<DestructibleP>();
                    if(destP!=null && gameObject.name=="player1") // not throw by camman
                    {
                        destP.killbyY1();
                    }
                    else if(destP!=null && gameObject.name=="player2") // throw by camman
                    {
                        destP.killbyY2();
                    }
                }
            }
        }
        
        // Remove grenade
        photonView.RPC("HideRG",RpcTarget.All);   
    }

    // [PunRPC] //#191
    // public void tran()
    // {
    //     Rigidbody rbt = gameObject.GetComponent<Rigidbody>(); 
    //     rbt.position= Synchronize.position;
    // }

    [PunRPC] 
    public void HideRG()
    {
        RemoteGrenade.active=false;
    }
    [PunRPC] 
    public void explosionEf()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
    }
    
    void des()
    {
        photonView.RPC("HideRG",RpcTarget.All); 
    }
    public void Reset(){
        hasExploded=false;
        CanExplode=0;
        throwed=0;
        box1.active=false;
        box2.active=false;
        box3.active=false;
        setting1.active = false;
        setting2.active = false;
        setting3.active = false;
        setting1sound.active=false;
        setting2sound.active=false;
        setting3sound.active=false;
        boxnum.active=false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        RemoteGrenade.active = false;

    }
}