using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingTerrian : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotateSpeed = 2F;

    public float rotateChangeCoolDownTime = 3;

    private float counter = 0;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
        counter += Time.deltaTime;
        if (counter >= rotateChangeCoolDownTime)
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                rotateSpeed = -rotateSpeed;
                counter = 0;
            }
        }
    }
    
    
}
