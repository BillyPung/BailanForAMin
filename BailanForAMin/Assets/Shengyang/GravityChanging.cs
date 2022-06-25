using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.Collections;
using UnityEngine;

public class GravityChanging : MonoBehaviour
{
    public float gravityMultiplier = 9.8f;
    public float rotateWaitTime = 10F, rotateCoolDownTime = 12F;
    private float coolDownTimeCounter;
    private bool upwards = true;
    public Camera mainCamera;

    private void Start()
    {
        coolDownTimeCounter = rotateCoolDownTime;
        Physics2D.gravity = Vector2.down * gravityMultiplier;
    }

    private void Update()
    {
        //print(Physics2D.gravity);
        coolDownTimeCounter += Time.deltaTime;
        if (coolDownTimeCounter > rotateCoolDownTime)
        {
            //print("it;s already cool down to rotate");
            if (Input.GetKeyDown(KeyCode.N))
            {
                //print("You pushed N");
                coolDownTimeCounter = 0;
                doGravityChanging();
            }
            else if (Input.GetKeyDown(KeyCode.M))
            {
                coolDownTimeCounter = 0;
                doGravityChanging();
            }
        }
    }

    // Update is called once per frame
    public void doGravityChanging()
    {
        //print("doGravityAll");
        //rotateCamera(turnClockwise);
        StartCoroutine(rotateWaiter());//turnClockwise));
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gravityChanging();
    }

    void rotateCamera(bool turnClockwise)
    {
        // Camera.main.transform.rotation = Quaternion.Euler(Vector2.forward * degrees);
        //Transform cameraTrans = Camera.main.transform;
        //cameraTrans.eulerAngles = Vector3.forward * degrees;
        // transform.eulerAngles = Vector3.forward * degrees;
        //transform.RotateAround (transform.position, Vector3.forward, degrees);
        //StartCoroutine(rotateWaiter(turnClockwise));
    }

    private IEnumerator rotateWaiter()
    {
        int degrees = 45;
       // if (turnClockwise) degrees = -degrees;
        float counter = 0;
        //Rotate 90 deg
        //transform.Rotate(new Vector3(90, 0, 0), Space.World);

        //Wait for 4 seconds

        while (counter < rotateWaitTime)
        {
            //Increment Timer until counter >= waitTime
            counter += Time.deltaTime;
           // transform.RotateAround(transform.position, Vector3.forward, degrees * Time.deltaTime);
            //mainCamera.transform.RotateAround(mainCamera.transform.position, Vector3.forward, degrees * Time.deltaTime);
            //Debug.Log("We have waited for: " + counter + " seconds");
            //Wait for a frame so that Unity doesn't freeze
            //Check if we want to quit this function

            yield return null;
        }
    }
    
     void gravityChanging()
    {
        //print("doGravityChanging");
        //Vector2 targetGravity = new Vector2();
        Vector2 currentGravity = Physics2D.gravity;
        Physics2D.gravity *= -1;
        upwards = !upwards;
        print(currentGravity);
        /*if (currentGravity == Vector2.down * gravityMultiplier)
        {
            if (turnClockWise)
            {
                Physics2D.gravity = new Vector2(-gravityMultiplier,0);
                print("Now the gravity is left");
            }
            else
            {
                Physics2D.gravity = new Vector2(gravityMultiplier,0);
                print("Now the gravity is right");
            }
        }
        else if (currentGravity == Vector2.left * gravityMultiplier)
        {
            
            if (turnClockWise)
            {
                Physics2D.gravity = new Vector2(0,gravityMultiplier);
                print("Now the gravity is up");
            }
            else
            {
                Physics2D.gravity = new Vector2(0,gravityMultiplier);
                print("Now the gravity is down");
            }
        }
        else if (currentGravity == Vector2.up * gravityMultiplier)
        {
            if (turnClockWise)
            {
                Physics2D.gravity = new Vector2(gravityMultiplier,0);
                print("Now the gravity is right");
            }
            else Physics2D.gravity = new Vector2(-gravityMultiplier,0);print("Now the gravity is left");
        }
        else if (currentGravity == Vector2.right * gravityMultiplier)
        {
            if (turnClockWise)
            {
                Physics2D.gravity = new Vector2(0,-gravityMultiplier);
                print("Now the gravity is down");
            }
            else Physics2D.gravity = new Vector2(0,gravityMultiplier); print("Now the gravity is up");
        }*/
        rotateHero();
    }

    void rotateHero()
    {
        if(upwards)
        {
            transform.Rotate(new Vector3(0, transform.rotation.y, 0), Space.World);
        }
        else
        {
            transform.Rotate(new Vector3(0, transform.rotation.y, 180), Space.World);
        }
        // if (Physics2D.gravity.x > 0)
        // {
        //     transform.eulerAngles = new Vector3(0, 0, 180);
        // }
        // else if (Physics2D.gravity.x < 0)
        // {
        //     transform.eulerAngles = Vector3.zero;
        // }
        // else if (Physics2D.gravity.y > 0)
        // {
        //     transform.eulerAngles = new Vector3(0, 0, -90);
        // }
        // else if (Physics2D.gravity.y < 0)
        // {
        //     transform.eulerAngles = new Vector3(0, 0, 90);
        // }
        /*{
            //transform.rotation.z = 0;
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        }
        else if (Physics2D.gravity == Vector2.left * gravityMultiplier)
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, -90);
        }
        else if (Physics2D.gravity == Vector2.up * gravityMultiplier)
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 180);
        }
        else if (Physics2D.gravity == Vector2.right * gravityMultiplier)
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 90);
        }*/

    }
}