using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;

public class FreezeAndChoose : MonoBehaviour
{
    private bool freeze = false;
    private int facing = 1;
    public float moveForce = 10f;
    private Collider2D hitCollider = null;
    public GameObject targetObject = null;
    public GameObject ice;
    private Image iceImage;

    private void Start()
    {
        //iceImage = ice.GetComponent<Image>();
    }

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
                if (hit.collider.gameObject.transform.childCount > 0)
                {
                    /*Vector3 targetPos = hit.collider.gameObject.transform.GetChild(0).transform.position;
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(
                        targetPos.x - hit.collider.gameObject.transform.position.x,
                        targetPos.y - transform.position.y); // * moveForce;*/
                    hitCollider = hit.collider;
                }
                else if (hit.collider.name == "MovablePlatform1")
                {
                    GameObject target =GameObject.Find("MP1Target");
                    print("active");
                    hit.collider.transform.position = Vector2.Lerp(hit.collider.transform.position,
                        target.transform.position, Time.deltaTime);
                }

                else
                {
                    print("it has no children");
                    if (facing == 1)
                    {
                        
                        hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveForce, 0);
                        print(hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity);
                    }
                    else if (facing == -1)
                    {
                        hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-moveForce, 0);
                        print(hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity);
                    }
                }

                //hit.collider.attachedRigidbody.AddForce(Vector2.up);
                Time.timeScale = 1;
                StaticVariable.pasueTime = !StaticVariable.pasueTime;
                freeze = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && freeze)
        {
            Time.timeScale = 1;
            StaticVariable.pasueTime = !StaticVariable.pasueTime;
            freeze = false;
        }

        if (hitCollider != null)
        {
            lerpMovePlatform(hitCollider);
        }
    }

    void lerpMovePlatform(Collider2D col)
    {
        col.transform.position =
            Vector2.Lerp(col.transform.position, targetObject.transform.position, Time.deltaTime);
        // col.transform.position =
        // Vector2.Lerp(col.transform.position, targetObject.transform.position, Time.deltaTime / 2);
        /*if(hitCollider.attachedRigidbody.velocity == Vector2.zero)
        {
            hitCollider.attachedRigidbody.velocity = new Vector2(0, 0);
            hitCollider = null;
        }*/
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