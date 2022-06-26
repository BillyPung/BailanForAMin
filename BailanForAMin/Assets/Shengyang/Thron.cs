using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thron : MonoBehaviour
{
    // Start is called before the first frame update
    ShowDeathUI showDeathUI;
    // Start is called before the first frame update
    void Start()
    {
        showDeathUI = GetComponent<ShowDeathUI>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //black screen and transport to saved location
            showDeathUI.showDeathUI();
            collision.transform.position = StaticVariable.savedLocation;
        }
    }
}
