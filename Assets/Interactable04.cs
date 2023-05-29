using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Interactable04 : MonoBehaviourPunCallbacks
{
    public GameObject theSupply4;
    public GameObject Object004;
    public void active4()
    {   
        photonView.RPC("active4rpc",RpcTarget.All);
    }

    [PunRPC] 
    public void active4rpc()
    {   
        Object004.GetComponent<MeshCollider>().enabled=true;
        theSupply4.GetComponent<Animation>().Play("Crate_Open");
    }

}
