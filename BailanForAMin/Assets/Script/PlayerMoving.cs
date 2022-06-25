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
    private bool isGround;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myFeet = GetComponent<BoxCollider2D>();
        myAnim = GetComponent<Animator>();
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
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            if (myRigidbody.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

    void run()
    {
        if (isGround)
        {
            float moveDir = Input.GetAxis("Horizontal");
            Vector2 playerVel = new Vector2(moveDir * runSpeed, myRigidbody.velocity.y);
            myRigidbody.velocity = playerVel;
            bool playerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
            myAnim.SetBool("walk", playerHasXAxisSpeed);
        }
    }

    void jump()
    {
        print("ready to jump");
        if (Input.GetKeyDown(KeyCode.Space)&& isGround )
        {
            print("im jumping");
            myAnim.SetBool("jumpUp", true);
            Vector2 playerVel = new Vector2(0, jumpSpeed);
            myRigidbody.velocity = playerVel;
           // myRigidbody.AddForce(playerVel, ForceMode2D.Force);
        }
    }
    
    void switchAnimation()
    {
        myAnim.SetBool("idle", false);
        if(myAnim.GetBool("jumpUp"))
        {
            if (myRigidbody.velocity.y < 0.0f)
            {
                myAnim.SetBool("jumpUp", false);
                myAnim.SetBool("jumpDown", true);
            }
        }
        else if(isGround)
        {
            myAnim.SetBool("jumpDown", false);
            myAnim.SetBool("idle", true);
        }
    }

    void freeze()
    {
        if(isGround)
        {
            myRigidbody.constraints = RigidbodyConstraints2D.None;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            myRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
    }
}
