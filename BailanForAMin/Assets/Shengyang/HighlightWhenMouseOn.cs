using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightWhenMouseOn : MonoBehaviour
{
    // Start is called before the first frame update
    private Color startcolor;
    public SpriteRenderer rend;
    void Start()
    {
       rend = GetComponent<SpriteRenderer>();
    }

    // The mesh goes red when the mouse is over it...
    void OnMouseEnter()
    {
        /*print("mouse enter");
        print(rend.material.color);*/
        if (StaticVariable.pasueTime) rend.color = Color.yellow;
        //print("now color is " + rend.material.color);
    }

    // ...the red fades out to cyan as the mouse is held over...
    /*void OnMouseOver()
    {
        rend.color -= new Color(0.1F, 0, 0) * Time.deltaTime;
    }*/

    // ...and the mesh finally turns white when the mouse moves away.
    void OnMouseExit()
    {
        rend.color = Color.white;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
        }

    }
    
}
