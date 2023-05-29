using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

// public class PlayerMovement : MonoBehaviour
public class PlayerMovement : MonoBehaviourPunCallbacks
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public float dashforce = 2000f;
    bool readyToJump;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    bool dashed=false;
    public Transform orientation;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    Rigidbody rb;
    public GameObject PostProcessHandlerx;

    [HideInInspector] public TextMeshProUGUI text_speed;

    // << 1 >>
    private void Start()
    {
        if (photonView.IsMine)
        {
            rb = GetComponent<Rigidbody>();
            rb.freezeRotation = true;
            readyToJump = true;
        }
    }
    // << 2 >>
    public GameObject dash;
    public GameObject dashcd;
    public GameObject dashcount;
    private void Update()
    {
        // print(transform.position);
        if (photonView.IsMine)
        {
            // ground check
            grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
            MyInput();
            SpeedControl();
            // handle drag
            if (grounded)
                rb.drag = groundDrag;
            else
                rb.drag = 0;
            // << dash >>
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("Player"); 
            if (Input.GetKey("v") && dashed==false && gos.Length == 2 && (verticalInput!=0||horizontalInput!=0))
            {
                PostProcessHandlerx.GetComponent<PostProcessHandler>().DoDashEffect();
                moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
                rb.AddForce(moveDirection.normalized * moveSpeed * dashforce, ForceMode.Force);
                dashed=true;
                Invoke("dashcding",10);
                dash.active = false;
                dashcd.active = true;
                dashcount.active = true;
            }
            // << dash >>
            // if (Input.GetKey("b"))
            // {
            //     if (dashed==true)
            //     {
            //         dashed=false;          
            //     }           
            // }    
            // << dash >>
            if(rb.velocity.y>11)
            {
                rb.AddForce(Vector3.down * 12f* rb.velocity.y, ForceMode.Force);
            }   
        }
    }
    // << 3 >>
    private void FixedUpdate()
    {
        if (photonView.IsMine)
        {        
            MovePlayer();
        }
    }
    private void dashcding()
    {
        if (photonView.IsMine)
        {
            if (dashed==true)
            {
                dashed=false;  
                dash.active = true;
                dashcd.active = false;
                dashcount.active = false;        
            }   
        }
    }
    // << 4 >>
    private void MyInput()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player"); 
        if (photonView.IsMine && gos.Length == 2)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
            // when to jump
            if(Input.GetKey(jumpKey) && readyToJump && grounded)
            {
                readyToJump = false;
                Jump();
                Invoke(nameof(ResetJump), jumpCooldown);
            }
        }
    }
    // << 5 >>
    private void MovePlayer()
    {
        if (photonView.IsMine)
        {
            // calculate movement direction
            moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
            // on ground
            if(grounded)
            {
                rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
            }
            // in air
            else if(!grounded)
            {
                rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
            }
        }
    }
    // << 6 >>
    private void SpeedControl()
    {
        if (photonView.IsMine)
        {
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            // limit velocity if needed
            if(flatVel.magnitude > moveSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * moveSpeed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
            // text_speed.SetText("Speed: " + flatVel.magnitude);
        }
    }
    // << 7 >>
    private void Jump()
    {
        if (photonView.IsMine)
        {
            // reset y velocity
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }
    // << 8 >>    
    private void ResetJump()
    {
        if (photonView.IsMine)
        {
            readyToJump = true;
        }
    }
}