using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Interactable01 : MonoBehaviourPunCallbacks
{
    public GameObject Object001;
    public GameObject effect001;
    public bool opened;
    public int stage;
    private float effectCountdown; // For effect duration
    private float effectCountdown2; // For effect duration
    public GameObject aus;

    void Start()
    {
        opened = false;
        effectCountdown = 15f;
        effectCountdown2 = 58f;
    }

    void Update()
    {
        effectCountdown -= Time.deltaTime;
        effectCountdown2 -= Time.deltaTime;

        if (effectCountdown2 <= 0f) 
        {
            transform.position += Vector3.down * 1f * Time.deltaTime;
        }

        if (effectCountdown <= 0f && effect001.active == true) // Disable effect after 15 seconds
        {
            effect001.active = false;
        }

        // --- For fading out crate ---
        // *** Have not found solution to rendering problem: if set material as transparent/fade, can see through

        // if (opened)        // If crate is opened, fade out
        // {
        //     var objRenderer = Object001.GetComponentInChildren<MeshRenderer>();
        //     var supplyRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
        //     float speed = 0.3f;
        //     Color modifiedColor = objRenderer.material.color;
        //     modifiedColor.a -= speed * Time.deltaTime;
        //     objRenderer.material.color = modifiedColor;
        //     supplyRenderer.material.color = modifiedColor;
        //     if (modifiedColor.a <= 0.0f) // When transparent, destroy object
        //     {
        //         Destroy(this.gameObject);
        //         Destroy(Object001);
        //         Destroy(effect001);
        //         Debug.Log("destroyed");
        //         opened = false;
        //     }
        // }
    }

    public void active()
    {
        photonView.RPC("activerpc", RpcTarget.All);
    }

    [PunRPC]
    public void activerpc()
    {
        Object001.GetComponent<MeshCollider>().enabled = true;
        this.gameObject.GetComponent<Animation>().Play("Crate_Open");
        opened = true;
        aus.active=true;
    }
}