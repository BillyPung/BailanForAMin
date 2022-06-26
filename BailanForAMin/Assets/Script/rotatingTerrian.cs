using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingTerrian : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotateSpeed = 2F;
    public float startSpeed = 2F;
    public float rotateChangeCoolDownTime = 3;

    private float counter = 0;
    // Update is called once per frame
    private void Update()
    {
        if (StaticVariable.stopRotate)
        {
            transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
            print("target is: " + StaticVariable.rotateTo + " now it is: " + transform.rotation.eulerAngles.z);
            counter += Time.deltaTime;
            if (transform.rotation.eulerAngles.z > StaticVariable.rotateTo)
            {
                rotateSpeed = -Mathf.Abs(rotateSpeed);
                counter = 0;
            }
            if (transform.rotation.eulerAngles.z < StaticVariable.rotateTo)
            {
                rotateSpeed = Mathf.Abs(rotateSpeed);
                counter = 0;
            }

        }
        else
        {
            transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Q))
            {
                rotateSpeed = -rotateSpeed;
                counter = 0;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                rotateSpeed = 0;
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                rotateSpeed = startSpeed;
            }
        }
    }
    
    
}
