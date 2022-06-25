using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathFloorScript : MonoBehaviour
{
    ShowDeathUI showDeathUI;
    // Start is called before the first frame update
    void Start()
    {
        showDeathUI = GetComponent<ShowDeathUI>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            //black screen and transport to saved location
            showDeathUI.showDeathUI();
            other.transform.position = StaticVariable.savedLocation;
        }
    }
}
