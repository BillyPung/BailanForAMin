using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float movingSpeed = 3;
    private Rigidbody2D myRigidbody;
    private int facing = 1;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        checkFacing();
        moveSelf();
    }
    
    void checkFacing()
    {
        if(transform.rotation.y < 0)
        {
            facing = -1;
        }
        else
        {
            facing = 1;
        }
    }
    void moveSelf()
    {
        if ((myRigidbody.velocity.y < 0.1f || myRigidbody.velocity.y >0.1f) && myRigidbody.velocity.x == 0)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                print("moving");
                myRigidbody.constraints = RigidbodyConstraints2D.None;
                myRigidbody.velocity = new Vector2(facing * movingSpeed, myRigidbody.velocity.y);
            }
        }
    }
}
