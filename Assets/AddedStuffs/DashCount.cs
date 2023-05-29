using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Photon.Pun;

public class DashCount : MonoBehaviourPunCallbacks
{
    public Text dashCountText;
    public float dashCount = 10f;

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {    
            if(dashCount>0)
            {
                dashCount -= Time.deltaTime;   
                dashCountText.text = " "+(dashCount+0.5).ToString("0");
                // Debug.Log(dashCountText.text);
                // Debug.Log(dashCount);

            }
            else
            {
                dashCount = 10f;
            }
        }
    }
}
