using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MoveCamera : MonoBehaviourPunCallbacks
{
    public Transform cameraPosition;
    public DestructibleP DestructibleP;
    public float cameraSpeed = 3f;

    private void Update()
    {
        if (photonView.IsMine)
        {
            transform.position = cameraPosition.position;
        } 
        // if (photonView.IsMine && DestructibleP.dead==0)
        // {
        //     transform.position = cameraPosition.position;
        // } 
        // else if(photonView.IsMine && transform.position.y<3)
        // {
        //     transform.position += Vector3.up * cameraSpeed * Time.deltaTime;
        // }
    }
}
