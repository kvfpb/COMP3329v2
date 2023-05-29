using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;

using UnityEngine.UI;

public class SupplyInteraction : MonoBehaviourPunCallbacks
{
    public grenadeNumber redcount;
    public grenadeNumber yellowcount;
    public grenadeNumber yellowcount2;
    public grenadeNumber yellowcount3;
    public grenadeNumber greencount;

    public GrenadeY GrenadeY;
    public GrenadeY2 GrenadeY2;
    public GrenadeY3 GrenadeY3;

    //==================================


    private void Update()
    {
        // if F is pressed and supply crate is within range
        // Update grenade count for current player, fade and destroy done in Interactable01.cs

        if (Input.GetKeyDown(KeyCode.F) && (photonView.IsMine))
        {
            float interactRange = 1f;
            Debug.Log("location: " + transform.position);
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

            // Check which supply crate (Interactable) is interacted with
            // Currently, will always be Interactable01, because that's the script used for every crate
            foreach (Collider collider in colliderArray) // Assume impossible to interact w/ >1 crate
            {
                if (collider.TryGetComponent(out Interactable01 Interactable01))
                {
                    if (Interactable01.opened == false) // First time accessing this crate
                    {
                        Interactable01.active();
                        if (Interactable01.stage == 1)
                        {
                            redcount.GetComponent<grenadeNumber>().count += 2;
                            if (yellowcount.GetComponent<grenadeNumberY>().count == " 0")
                            {
                                GrenadeY.upthrowed();
                                yellowcount.GetComponent<grenadeNumberY>().count = " 1";
                            }
                            if (yellowcount2.GetComponent<grenadeNumberY>().count == " 0")
                            {
                                GrenadeY2.upthrowed();
                                yellowcount2.GetComponent<grenadeNumberY>().count = " 1";
                            }
                            if (yellowcount3.GetComponent<grenadeNumberY>().count == " 0")
                            {
                                GrenadeY3.upthrowed();
                                yellowcount3.GetComponent<grenadeNumberY>().count = " 1";
                            }
                            greencount.GetComponent<grenadeNumber>().count += 1;
                        }
                        else if (Interactable01.stage == 2)
                        {
                            redcount.GetComponent<grenadeNumber>().count += 3;
                            if (yellowcount.GetComponent<grenadeNumberY>().count == " 0")
                            {
                                GrenadeY.upthrowed();
                                yellowcount.GetComponent<grenadeNumberY>().count = " 1";
                            }
                            if (yellowcount2.GetComponent<grenadeNumberY>().count == " 0")
                            {
                                GrenadeY2.upthrowed();
                                yellowcount2.GetComponent<grenadeNumberY>().count = " 1";
                            }
                            if (yellowcount3.GetComponent<grenadeNumberY>().count == " 0")
                            {
                                GrenadeY3.upthrowed();
                                yellowcount3.GetComponent<grenadeNumberY>().count = " 1";
                            }
                            greencount.GetComponent<grenadeNumber>().count += 1;
                        }
                        else if (Interactable01.stage == 3)
                        {
                            redcount.GetComponent<grenadeNumber>().count += 4;
                            if (yellowcount.GetComponent<grenadeNumberY>().count == " 0")
                            {
                                GrenadeY.upthrowed();
                                yellowcount.GetComponent<grenadeNumberY>().count = " 1";
                            }
                            if (yellowcount2.GetComponent<grenadeNumberY>().count == " 0")
                            {
                                GrenadeY2.upthrowed();
                                yellowcount2.GetComponent<grenadeNumberY>().count = " 1";
                            }
                            if (yellowcount3.GetComponent<grenadeNumberY>().count == " 0")
                            {
                                GrenadeY3.upthrowed();
                                yellowcount3.GetComponent<grenadeNumberY>().count = " 1";
                            }
                            greencount.GetComponent<grenadeNumber>().count += 2;
                        }
                        else if (Interactable01.stage == 4)
                        {
                            redcount.GetComponent<grenadeNumber>().count += 5;
                            if (yellowcount.GetComponent<grenadeNumberY>().count == " 0")
                            {
                                GrenadeY.upthrowed();
                                yellowcount.GetComponent<grenadeNumberY>().count = " 1";
                            }
                            if (yellowcount2.GetComponent<grenadeNumberY>().count == " 0")
                            {
                                GrenadeY2.upthrowed();
                                yellowcount2.GetComponent<grenadeNumberY>().count = " 1";
                            }
                            if (yellowcount3.GetComponent<grenadeNumberY>().count == " 0")
                            {
                                GrenadeY3.upthrowed();
                                yellowcount3.GetComponent<grenadeNumberY>().count = " 1";
                            }
                            greencount.GetComponent<grenadeNumber>().count += 2;
                        }
                    }
                }
            }
        }
    }
}
