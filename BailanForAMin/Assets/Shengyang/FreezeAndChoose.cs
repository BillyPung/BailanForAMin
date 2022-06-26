using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class FreezeAndChoose : MonoBehaviour
{
    private bool freeze = false;
    private int facing = 1;
    public float moveForce = 10f;
    

    private void Update()
    {
        facing = PlayerMoving.facing;
        if (Input.GetMouseButtonDown(0) && freeze)
        {
            print("freeze and choose");
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null && hit.collider.tag == "MovablePlatform")
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero; //stop moving
                Debug.Log(hit.collider.gameObject.name);
                //hit.collider.isTrigger = true;
                if (facing == 1)
                {
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveForce, 0);
                    print(hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity);
                }
                else if(facing == -1)
                {
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-moveForce, 0);
                    print(hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity);
                }
                //hit.collider.attachedRigidbody.AddForce(Vector2.up);
                Time.timeScale = 1;
                StaticVariable.pasueTime = !StaticVariable.pasueTime;
            }
        }
        if(Input.GetKeyDown(KeyCode.Space) && freeze)
        {
            Time.timeScale = 1;
            StaticVariable.pasueTime = !StaticVariable.pasueTime;
            freeze = false;
        }
    }

    public void waitingForObjectToPassSpeed()
    {
        freeze = true;
    }

    /*void speedMoved()
    {
        
    }*/
    public void OnMouseEnter()
    {
        //throw new NotImplementedException();
        //print("2waiting for object to pass speed");
        /*RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
 
        if(hit.collider != null && Time.timeScale == 0)
        {
            Debug.Log ("Target name: " + hit.collider.name);
            if(hit.collider.name == "Freeze")
            {
                Time.timeScale = 1;
            }
            else if(hit.collider.name == "Unfreeze")
            {
                Time.timeScale = 0;
            }
        }*/
    }
}
