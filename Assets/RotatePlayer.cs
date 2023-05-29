using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RotatePlayer : MonoBehaviourPunCallbacks
{
    public Transform playerrotation;

    private void Update()
    {
        if (photonView.IsMine)
        {
            transform.rotation = playerrotation.rotation;
        } 
    }

}
