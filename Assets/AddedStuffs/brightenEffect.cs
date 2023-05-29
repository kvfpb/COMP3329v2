using UnityEngine;
using UnityEngine.UI;
using System;
using Photon.Pun;


public class brightenEffect : MonoBehaviourPunCallbacks
{
    public GameObject lightEffect;
    private int endint=0;
    // Update is called once per frame
    void Update()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("cutscene"); 
        if(gos.Length == 2)
        {
            endint=0;
            transform.GetComponent<RectTransform>().localPosition = new Vector3(-878f, -470f, 10f);
        }
        GameObject[] gos2;
        gos2 = GameObject.FindGameObjectsWithTag("endGame");
        if(gos2.Length > 0)
        {
            endint=1;
        } 
        if(endint == 0)
        {
            if (photonView.IsMine)
            {
                if (Input.GetKey("q"))
                {
                    transform.GetComponent<RectTransform>().localPosition = new Vector3(-878f, -470f, 10f);
                }
                if (Input.GetKey("1"))
                {
                    transform.GetComponent<RectTransform>().localPosition = new Vector3(-778f, -470f, 10f);
                }
                if (Input.GetKey("2"))
                {
                    transform.GetComponent<RectTransform>().localPosition = new Vector3(-678f, -470f, 10f);
                }
                if (Input.GetKey("3"))
                {
                    transform.GetComponent<RectTransform>().localPosition = new Vector3(-578f, -470f, 10f);
                }
                if (Input.GetKey("e"))
                {
                    transform.GetComponent<RectTransform>().localPosition = new Vector3(-478f, -470f, 10f);
                }
            }
        }
    }
}