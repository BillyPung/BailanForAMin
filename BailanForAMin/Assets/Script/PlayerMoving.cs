using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public float runSpeed;
    public float jumpSpeed;

    private Rigidbody2D myRigidbody;
    private Animator myAnim;
    private BoxCollider2D myFeet;
    public float gravityMultiplier = 9.8f;
    public static bool isGround;
    public static int facing = 1; //1 is facing right, while -1 is facing left

    private void Awake()
    {
       // StaticVariable.savedLocation = transform.position;
    }

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myFeet = GetComponent<BoxCollider2D>();
        myAnim = GetComponent<Animator>();
        //myRigidbody.centerOfMass = transform.Find("CenterOfGravity").transform.position;
    }

    private void Update()
    {
        flip();
        run();
        jump();
        freeze();
        checkGrounded();
        switchAnimation();
    }

    void checkGrounded()
    {
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }

    void flip()
    {
        bool playerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasXAxisSpeed)
        {
            if (myRigidbody.velocity.x > 0.1f)
            {
                facing = 1;
                if(Physics2D.gravity.y < 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 180, 180);
                }
            }

            if (myRigidbody.velocity.x < -0.1f)
            {
                facing = -1;
                
                if(Physics2D.gravity.y < 0)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 0, 180);
                }
            }
        }
        
    }

    void run()
    {
            float moveDir = Input.GetAxis("Horizontal");
            Vector2 playerVel = new Vector2(moveDir * runSpeed, myRigidbody.velocity.y);
            //Vector2.SmoothDamp()
            myRigidbody.velocity = playerVel;
            bool playerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
            myAnim.SetBool("walk", playerHasXAxisSpeed);
    }

    void jump()
    {
        //print("ready to jump");
        if (Input.GetKeyDown(KeyCode.Space)&& isGround )
        {
            //print("im jumping");
            myAnim.SetBool("jumpUp", true);
            //Vector2 playerVel = new Vector2(0, jumpSpeed);
            Vector2 playerVel = Physics2D.gravity / gravityMultiplier * -jumpSpeed;
            print("playerVel" + playerVel);
            myRigidbody.velocity = playerVel;
           // myRigidbody.AddForce(playerVel, ForceMode2D.Force);
        }
    }
    
    void switchAnimation()
    {
        myAnim.SetBool("idle", false);
        if (myRigidbody.velocity.x == 0 && myRigidbody.velocity.y < -1) 
        {
            myAnim.SetBool("jumpDown", false);
            myAnim.SetBool("jumpUp", false);
            myAnim.SetBool("drop", true);
        }
        else if(myAnim.GetBool("jumpUp"))
        {
            if (myRigidbody.velocity.y < 0.0f)
            {
                myAnim.SetBool("jumpUp", false);
                myAnim.SetBool("jumpDown", true);
            }
        }
        else if(isGround)
        {
            myAnim.SetBool("drop", false);
            myAnim.SetBool("jumpDown", false);
            myAnim.SetBool("idle", true);
        }
    }

    void freeze()
    {
        if (isGround)
        {
            myRigidbody.constraints = RigidbodyConstraints2D.None;
        }

        if (Input.GetKeyDown(KeyCode.F) && !isGround)

        {
            StaticVariable.pasueTime = !StaticVariable.pasueTime;
            Time.timeScale = 0;
            myRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;
            myRigidbody.velocity = Vector2.zero;
            GetComponent<FreezeAndChoose>().waitingForObjectToPassSpeed();
        }

    }
}
