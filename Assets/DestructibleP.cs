using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
// User -> Player
public class DestructibleP : MonoBehaviourPunCallbacks
{
	public GameObject destroyedVersion;	
	public GameObject PlayerMovementx;
	public GameObject GrenadeThrowerx;
	public GameObject SupplyInteractionx;
	public GameObject PostProcessHandlerx;
	//====================================
	public GameObject endGame;
	public GameObject killer;
	public GameObject killbyRin;
	public GameObject killbyYin;
	public GameObject killbyGin;
	public GameObject killbyOin;
	//====================================
 	private bool barriered=false;
 	private bool barriering=false;
    public GameObject barrierA;
    public GameObject barrierB;
    public GameObject barrierC;
    public GameObject barrierV;
	//====================================
    public GameObject Grey1;
    public GameObject Grey2;
    public GameObject Grey3;
    public GameObject user;
	public GameObject barrierObject;
	//====================================
	private int gameended=0;
	public int dead=0;
	public int stage=0;
	private bool doDeadEffect = false;
	
// ==================================================================================================
    public void killbyR1()
    {
        photonView.RPC("killbyR",RpcTarget.All);
		photonView.RPC("Destroy2",RpcTarget.All);
	}
    public void killbyR2()
    {
        photonView.RPC("killbyR",RpcTarget.All);
		photonView.RPC("selfDestroy2",RpcTarget.All); 
	}
	[PunRPC]
    public void killbyR()
    {
        Rigidbody rb = Instantiate(killbyRin, transform.position, transform.rotation).GetComponent<Rigidbody>();
    }
// ==================================================================================================
    public void killbyY1()
    {
        photonView.RPC("killbyY",RpcTarget.All);
		photonView.RPC("Destroy2",RpcTarget.All);
	}
    public void killbyY2()
    {
        photonView.RPC("killbyY",RpcTarget.All);
		photonView.RPC("selfDestroy2",RpcTarget.All); 
	}
	[PunRPC]
    public void killbyY()
    {
        Rigidbody rb = Instantiate(killbyYin, transform.position, transform.rotation).GetComponent<Rigidbody>();
    }
// ==================================================================================================
    public void killbyG1()
    {
        photonView.RPC("killbyG",RpcTarget.All); 
		photonView.RPC("Destroy2",RpcTarget.All);
    }
    public void killbyG2()
    {
        photonView.RPC("killbyG",RpcTarget.All); 
		photonView.RPC("selfDestroy2",RpcTarget.All); 
    }
	[PunRPC]
    public void killbyG()
    {
        Rigidbody rb = Instantiate(killbyGin, transform.position, transform.rotation).GetComponent<Rigidbody>();
    }
// ==================================================================================================
	public void Destroy ()
	{
		photonView.RPC("Destroy2",RpcTarget.All); 
	}
    [PunRPC] 
    public void Destroy2()
    {
		if ((barriering==false && dead==0)||(barriering==true && dead==0 && transform.position.y<-10))
		{
			var rotationVector = transform.rotation.eulerAngles;
			rotationVector.x = 90;
			transform.rotation = Quaternion.Euler(rotationVector);
			//=====================================================
			PlayerMovementx.GetComponent<PlayerMovement>().enabled = false;
			GrenadeThrowerx.GetComponent<GrenadeThrower>().enabled = false;
			SupplyInteractionx.GetComponent<SupplyInteraction>().enabled = false;
			//=====================================================
			GameObject[] gos;
			gos = GameObject.FindGameObjectsWithTag("Player");	
			Rigidbody rb = Instantiate(endGame, transform.position, transform.rotation).GetComponent<Rigidbody>();		
			PostProcessHandlerx.GetComponent<PostProcessHandler>().DoGetHitEffect();
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
			if(gos[0].name=="player2"||gos[1].name=="player2")
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
			//=====================================================
			Rigidbody rb2 = Instantiate(killer, transform.position, transform.rotation).GetComponent<Rigidbody>();
			rb2.name="player1";
			dead=1;
		}
    }
    [PunRPC] 
    public void selfDestroy2()
    {
		if ((barriering==false && dead==0)||(barriering==true && dead==0 && transform.position.y<-10))
		{
			var rotationVector = transform.rotation.eulerAngles;
			rotationVector.x = 90;
			transform.rotation = Quaternion.Euler(rotationVector);
			//=====================================================
			PlayerMovementx.GetComponent<PlayerMovement>().enabled = false;
			GrenadeThrowerx.GetComponent<GrenadeThrower>().enabled = false;
			SupplyInteractionx.GetComponent<SupplyInteraction>().enabled = false;
			//=====================================================
			GameObject[] gos;
			gos = GameObject.FindGameObjectsWithTag("Player");
			Rigidbody rb = Instantiate(endGame, transform.position, transform.rotation).GetComponent<Rigidbody>();
			if(gos[0].name=="player2"||gos[1].name=="player2")
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
			//=====================================================
			Rigidbody rb2 = Instantiate(killer, transform.position, transform.rotation).GetComponent<Rigidbody>();
			rb2.name="player2";
			dead=1;
		}
    }
// ==================================================================================================
	[PunRPC]
    public void killbyO()
    {
        Rigidbody rb2 = Instantiate(killbyOin, transform.position, transform.rotation).GetComponent<Rigidbody>();
    }
// ==================================================================================================
	void Update()
	{
		GameObject[] gosc;
        gosc = GameObject.FindGameObjectsWithTag("cutscene");
        GameObject[] gos2;
        gos2 = GameObject.FindGameObjectsWithTag("endGame");
		if (gos2.Length == 0 && gosc.Length == 0 && transform.position.y<-10 && dead==0)
		{
			photonView.RPC("Destroy2",RpcTarget.All);
        	photonView.RPC("killbyO",RpcTarget.All);
			dead=1;
		}
		if (transform.position.y<-10)
		{
			Rigidbody rb = GetComponent<Rigidbody>();
			rb.useGravity = false;
			float customGravity = 0.1f;
			rb.AddForce(Vector3.down * customGravity, ForceMode.Acceleration);
			// rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
			// rb.constraints = RigidbodyConstraints.None;
		}
		else
		{
			Rigidbody rb = GetComponent<Rigidbody>();
			rb.useGravity = true;
		}
		//=====================================================
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player"); 
		if (Input.GetKey("r") && barriered==false && gameended==0 && gos.Length == 2)
		{
			if (photonView.IsMine)
			{
				StartCoroutine(BarrierEffect());
				barriered=true;
				Invoke("barrierend",5);
				barrierA.active = false;
				barrierB.active = true;
				Grey1.active = true;
				Grey2.active = true;
				Grey3.active = true;
				photonView.RPC("barrier",RpcTarget.All);
			}
		}
		//=====================================================
        // GameObject[] gos2;
        // gos2 = GameObject.FindGameObjectsWithTag("endGame");  
        if(gos2.Length >= 1)
        {
			
			if(photonView.IsMine){
				if(doDeadEffect == false){
					Debug.Log("DeadScene");
					PostProcessHandlerx.GetComponent<PostProcessHandler>().doDead = true;
					doDeadEffect = true;
				}
			}
			gameended=1;
			PlayerMovementx.GetComponent<PlayerMovement>().enabled = false;
			GrenadeThrowerx.GetComponent<GrenadeThrower>().enabled = false;
			SupplyInteractionx.GetComponent<SupplyInteraction>().enabled = false;
        } 
		//=====================================================    
        // GameObject[] gosc;
        // gosc = GameObject.FindGameObjectsWithTag("cutscene");
        if(gosc.Length == 2 && stage==0)
        {  
			barriered=false;

			barrierA.active = true;
			barrierC.active = false;
			Grey1.active = false;
			Grey2.active = false;
			Grey3.active = false;

			gameended=0;
			dead=0;
        	photonView.RPC("ReDestory",RpcTarget.All); 
			stage=1;
		}
        if(gosc.Length == 0 && stage==1)
        {  
			stage=0;
		}
	}
// ==================================================================================================
    [PunRPC] 
    public void ReDestory()
    {
		var rotationVector = transform.rotation.eulerAngles;
		rotationVector.x = 0;
		transform.rotation = Quaternion.Euler(rotationVector);
		PlayerMovementx.GetComponent<PlayerMovement>().enabled = true;
		GrenadeThrowerx.GetComponent<GrenadeThrower>().enabled = true;
		SupplyInteractionx.GetComponent<SupplyInteraction>().enabled = true;
    }
// ==================================================================================================
	private void barrierend()
	{
        if (photonView.IsMine)
        {
			// barriering=false;
			barrierB.active = false;
			barrierC.active = true;
			Grey1.active = false;
			Grey2.active = false;
			Grey3.active = false;
			// barrierV.active = false;
			photonView.RPC("barrierend2",RpcTarget.All);
		}		
	}
    public int gasbarrier() //#187
    {
		if(barriering==true)
		{
			return 1;
		}
		else
		{
			return 0;
		}		
    }
    [PunRPC] 
    public void barrier()
    {
		barriering=true;
		barrierV.active = true;
    }
    [PunRPC] 
    public void barrierend2()
    {
		barriering=false;
		barrierV.active = false;
    }
	IEnumerator BarrierEffect(){
		barrierObject.SetActive(true);
		yield return new WaitForSeconds(3.5f);
		Color temp = barrierObject.GetComponent<Image>().color;
		temp.a = 0.7f;
		barrierObject.GetComponent<Image>().color = temp;
		yield return new WaitForSeconds(1.5f);
		temp.a = 1f;
		barrierObject.SetActive(false);
	}
}
