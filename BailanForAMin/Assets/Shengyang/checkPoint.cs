using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{
    private void Update()
    {
        print(StaticVariable.savedLocation);
        StaticVariable.savedLocation = transform.position;
    }
    // Start is called before the first frame update
}
