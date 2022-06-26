using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTo : MonoBehaviour
{
    public float rotateTo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("rotate to " + rotateTo);
        if (collision.gameObject.tag == "Player")
        {
            StaticVariable.stopRotate = true;
            StaticVariable.rotateTo = rotateTo;
        }
    }
}
