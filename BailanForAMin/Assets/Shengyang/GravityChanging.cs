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
    private float coolDownTimeCounter = 0;

    private void Start()
    {
        Physics2D.gravity = Vector2.down * gravityMultiplier;
    }

    private void Update()
    {
        //print(Physics2D.gravity);
        coolDownTimeCounter += Time.deltaTime;
        if (coolDownTimeCounter > rotateCoolDownTime)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                //print("You pushed N");
                coolDownTimeCounter = 0;
                doGravityChanging(true);
            }
            else if (Input.GetKeyDown(KeyCode.M))
            {
                coolDownTimeCounter = 0;
                doGravityChanging(false);
            }
        }
    }

    // Update is called once per frame
    public void doGravityChanging(bool turnClockwise)
    {
        //print("doGravityAll");
        //rotateCamera(turnClockwise);
        StartCoroutine(rotateWaiter(turnClockwise));
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gravityChanging(turnClockwise);
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

    private IEnumerator rotateWaiter(bool turnClockwise)
    {
        int degrees = 90;
        if (turnClockwise) degrees = -degrees;
        float counter = 0;
        //Rotate 90 deg
        //transform.Rotate(new Vector3(90, 0, 0), Space.World);

        //Wait for 4 seconds

        while (counter < rotateWaitTime)
        {
            //Increment Timer until counter >= waitTime
            counter += Time.deltaTime;
            transform.RotateAround(transform.position, Vector3.forward, degrees * Time.deltaTime);
            //Debug.Log("We have waited for: " + counter + " seconds");
            //Wait for a frame so that Unity doesn't freeze
            //Check if we want to quit this function

            yield return null;
        }
    }

    void gravityChanging(bool turnClockWise)
    {
        //print("doGravityChanging");
        //Vector2 targetGravity = new Vector2();
        Vector2 currentGravity = Physics2D.gravity;

        print(currentGravity);
        if (currentGravity == Vector2.down * gravityMultiplier)
        {
            print("Now the gravity is down");
            if (turnClockWise)
            {
                Physics2D.gravity = Vector2.left * gravityMultiplier;
            }
            else Physics2D.gravity = Vector2.right * gravityMultiplier;
        }
        else if (currentGravity == Vector2.left * gravityMultiplier)
        {
            print("Now the gravity is left");
            if (turnClockWise)
                Physics2D.gravity = Vector2.up * gravityMultiplier;
            else Physics2D.gravity = Vector2.down * gravityMultiplier;
        }
        else if (currentGravity == Vector2.up * gravityMultiplier)
        {
            if (turnClockWise)
                Physics2D.gravity = Vector2.right * gravityMultiplier;
            else Physics2D.gravity = Vector2.left * gravityMultiplier;
        }
        else if (currentGravity == Vector2.right * gravityMultiplier)
        {
            if (turnClockWise) Physics2D.gravity = Vector2.down * gravityMultiplier;
            else Physics2D.gravity = Vector2.up * gravityMultiplier;
        }
    }
}