using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeAndChoose : MonoBehaviour
{
    private Color startColor;
    // Start is called before the first frame update
    public void Freeze()
    {
        Time.timeScale = 0;
    }


    public void OnMouseEnter()
    {
        throw new NotImplementedException();
    }
}
