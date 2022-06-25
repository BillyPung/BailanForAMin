using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipActiver : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tipToBeActive;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
            tipToBeActive.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
            tipToBeActive.SetActive(false);
    }

    // Update is called once per frame
    
}
