using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingTerrian : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotateSpeed = 2F;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
    }
}
