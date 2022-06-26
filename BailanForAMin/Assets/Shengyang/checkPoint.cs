using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{

    private BoxCollider2D boxCollider2D;

    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if(StaticVariable.checkPointName == gameObject.name)
        {
            print("save " + gameObject.name + transform.position);
            StaticVariable.savedLocation = transform.position;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("check" + gameObject.name);
            StaticVariable.checkPointName = gameObject.name;
            boxCollider2D.enabled = false;
        }
    }
}
