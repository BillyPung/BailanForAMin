using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathFloorScript : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //black screen and transport to saved location
            other.transform.position = StaticVariable.savedLocation;
        }
    }
}
