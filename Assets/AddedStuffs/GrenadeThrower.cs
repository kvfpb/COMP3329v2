using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
// User -> CameraHolder -> PlayerCam
public class GrenadeThrower : MonoBehaviourPunCallbacks
{
    public float throwForce = 20f;
    public float throwForceY = 10f;
    //======================================
    public GameObject grenadePrefab;
    public GameObject grenadePrefabG;
    public GameObject RemoteGrenade;
    public GameObject RemoteGrenade2;
    public GameObject RemoteGrenade3;
    //======================================
    public grenadeNumber redcount;
    public grenadeNumberY yellowcount; 
    public grenadeNumberY yellowcount2;
    public grenadeNumberY yellowcount3;
    public grenadeNumber greencount;  
    [SerializeField]
    private int currentGrenade=0;
    //====================================== 
    public Transform originTransform;
    public Transform originTransformf;
    //======================================
 	private bool barriered=false;
 	private bool barriering=false;
    //======================================
    public GameObject setting1;
    public GameObject setting2;
    public GameObject setting3;
    public GameObject setting12;
    public GameObject setting22;
    public GameObject setting32;
    public GameObject setting13;
    public GameObject setting23;
    public GameObject setting33;
    //======================================
    public GameObject user;
    private int stage=0;
//================================================================================
    void Update()
    {     
        if (photonView.IsMine)
        {
            if (Input.GetKey("r") && barriered==false)
            {
				barriered=true;
				barriering=true;
                Invoke("barrierend",5);
            }
            if (Input.GetKey("q"))
            {
				currentGrenade=0;
            }
            if (Input.GetKey("1"))
            {
				currentGrenade=1;
            }
            if (Input.GetKey("2"))
            {
				currentGrenade=2;
            }
            if (Input.GetKey("3"))
            {
				currentGrenade=3;
            }
            if (Input.GetKey("e"))
            {
				currentGrenade=4;
            }
		}
        //===================================================
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player"); 
        if (photonView.IsMine && barriering==false && gos.Length == 2)
        {
            if(Input.GetMouseButtonDown(0) && redcount.GetComponent<grenadeNumber>().count>0 && currentGrenade==0)
            {
                redcount.GetComponent<grenadeNumber>().count=redcount.GetComponent<grenadeNumber>().count-1;
                photonView.RPC("ThrowGrenade",RpcTarget.All);
                // ThrowGrenade();
            }
            else if(Input.GetMouseButtonDown(0) && yellowcount.GetComponent<grenadeNumberY>().count==" 1" && currentGrenade==1)
            {
                setting1.active=true;
                setting2.active=true;
                setting3.active=true;
                yellowcount.GetComponent<grenadeNumberY>().count=" R";
                photonView.RPC("ThrowGrenadeY",RpcTarget.All);
                // ThrowGrenade();
            }
            else if(Input.GetMouseButtonDown(0) && yellowcount2.GetComponent<grenadeNumberY>().count==" 1" && currentGrenade==2)
            {
                setting12.active=true;
                setting22.active=true;
                setting32.active=true;
                yellowcount2.GetComponent<grenadeNumberY>().count=" R";
                photonView.RPC("ThrowGrenadeY2",RpcTarget.All);
                // ThrowGrenade();
            }
            else if(Input.GetMouseButtonDown(0) && yellowcount3.GetComponent<grenadeNumberY>().count==" 1" && currentGrenade==3)
            {
                setting13.active=true;
                setting23.active=true;
                setting33.active=true;
                yellowcount3.GetComponent<grenadeNumberY>().count=" R";
                photonView.RPC("ThrowGrenadeY3",RpcTarget.All);
                // ThrowGrenade();
            }
            else if(Input.GetMouseButtonDown(0) && greencount.GetComponent<grenadeNumber>().count>0 && currentGrenade==4)
            {
                greencount.GetComponent<grenadeNumber>().count=greencount.GetComponent<grenadeNumber>().count-1;
                photonView.RPC("ThrowGrenadeG",RpcTarget.All);
                // ThrowGrenade();
            }
        }
        //===================================================
        GameObject[] gosc;
        gosc = GameObject.FindGameObjectsWithTag("cutscene");
        if(gosc.Length == 2 && stage==0)
        {            
            setting1.active=false;
            setting2.active=false;
            setting3.active=false; 
            setting12.active=false;
            setting22.active=false;
            setting32.active=false;  
            setting13.active=false;
            setting23.active=false;
            setting33.active=false;   
			currentGrenade=0;
            redcount.GetComponent<grenadeNumber>().count=5;
            yellowcount.GetComponent<grenadeNumberY>().count=" 1";
            yellowcount2.GetComponent<grenadeNumberY>().count=" 1";
            yellowcount3.GetComponent<grenadeNumberY>().count=" 1";
            greencount.GetComponent<grenadeNumber>().count=2;
			stage=1;
		}
        if(gosc.Length == 0 && stage==1)
        {  
			stage=0;
		}
    }
//================================================================================
	private void barrierend()
	{
        if (photonView.IsMine)
        {
			barriering=false;
		}
	}
//================================================================================
    [PunRPC] 
    public void ThrowGrenade()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        Rigidbody rb = Instantiate(grenadePrefab, originTransform.position, originTransform.rotation).GetComponent<Rigidbody>(); 
        if(gos[0].name=="player1"||gos[1].name=="player1" )
        {
            if(user.name=="player1")
            {
                rb.name=user.name;
            }            
            else
            {
                rb.name="player2";
            } 
        }
        if(gos[0].name=="player2"||gos[1].name=="player2" )
        {
            if(user.name=="player2")
            {
                rb.name=user.name;
            }            
            else
            {
                rb.name="player1";
            } 
        }  
        if (photonView.IsMine)
        {
            rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
        }
        else
        {
            rb.AddForce(originTransform.forward * throwForce, ForceMode.VelocityChange);
        }
    }
//================================================================================
    [PunRPC] 
    public void ThrowGrenadeG()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        Rigidbody rb = Instantiate(grenadePrefabG, originTransform.position, originTransform.rotation).GetComponent<Rigidbody>(); 
        if(gos[0].name=="player1"||gos[1].name=="player1" )
        {
            if(user.name=="player1")
            {
                rb.name=user.name;
            }            
            else
            {
                rb.name="player2";
            } 
        }
        if(gos[0].name=="player2"||gos[1].name=="player2" )
        {
            if(user.name=="player2")
            {
                rb.name=user.name;
            }            
            else
            {
                rb.name="player1";
            } 
        }
        if (photonView.IsMine)
        {
            rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
        }
        else
        {
            rb.AddForce(originTransform.forward * throwForce, ForceMode.VelocityChange);
        }
    }
//================================================================================
    [PunRPC] 
    public void ThrowGrenadeY()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        RemoteGrenade.active=true;
        Rigidbody rb = RemoteGrenade.GetComponent<Rigidbody>(); 
        if(gos[0].name=="player1"||gos[1].name=="player1" )
        {
            if(user.name=="player1")
            {
                rb.name=user.name;
            }            
            else
            {
                rb.name="player2";
            } 
        }
        if(gos[0].name=="player2"||gos[1].name=="player2" )
        {
            if(user.name=="player2")
            {
                rb.name=user.name;
            }            
            else
            {
                rb.name="player1";
            } 
        }
        rb.position= originTransform.position;
        rb.rotation= originTransform.rotation; 
        // RemoteGrenade.active=false;
        if (photonView.IsMine)
        {
            rb.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
        }
        else
        {
            rb.GetComponent<Rigidbody>().AddForce(originTransform.forward * throwForce, ForceMode.VelocityChange);
        }
    }
//================================================================================
    [PunRPC] 
    public void ThrowGrenadeY2()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        RemoteGrenade2.active=true;
        Rigidbody rb = RemoteGrenade2.GetComponent<Rigidbody>();
        if(gos[0].name=="player1"||gos[1].name=="player1" )
        {
            if(user.name=="player1")
            {
                rb.name=user.name;
            }            
            else
            {
                rb.name="player2";
            } 
        }
        if(gos[0].name=="player2"||gos[1].name=="player2" )
        {
            if(user.name=="player2")
            {
                rb.name=user.name;
            }            
            else
            {
                rb.name="player1";
            } 
        }
        rb.position= originTransform.position;
        rb.rotation= originTransform.rotation; 
        // RemoteGrenade.active=false;
        if (photonView.IsMine)
        {
            rb.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
        }
        else
        {
            rb.GetComponent<Rigidbody>().AddForce(originTransform.forward * throwForce, ForceMode.VelocityChange);
        }
    }
//================================================================================
    [PunRPC] 
    public void ThrowGrenadeY3()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        RemoteGrenade3.active=true;
        Rigidbody rb = RemoteGrenade3.GetComponent<Rigidbody>();
        if(gos[0].name=="player1"||gos[1].name=="player1" )
        {
            if(user.name=="player1")
            {
                rb.name=user.name;
            }            
            else
            {
                rb.name="player2";
            } 
        }
        if(gos[0].name=="player2"||gos[1].name=="player2" )
        {
            if(user.name=="player2")
            {
                rb.name=user.name;
            }            
            else
            {
                rb.name="player1";
            } 
        }
        rb.position= originTransform.position;
        rb.rotation= originTransform.rotation; 
        if (photonView.IsMine)
        {
            rb.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
        }
        else
        {
            rb.GetComponent<Rigidbody>().AddForce(originTransform.forward * throwForce, ForceMode.VelocityChange);
        }
    }
}
