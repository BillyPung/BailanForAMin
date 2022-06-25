using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("checkpoint");
            StaticVariable.savedLocation = transform.position;
        }
        
    }
}
