using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class iceImageActiver : MonoBehaviour
{
    // Start is called before the first frame update
    private Image iceImage;
    // Update is called once per frame
    void Start()
    {
        iceImage = GetComponent<Image>();
    }
    void Update()
    {
        print("staticvariable" + StaticVariable.pasueTime);
        if (StaticVariable.pasueTime)
        {
            var tempColor = iceImage.color;
            tempColor.a = 0.3f;
            iceImage.color = tempColor;
        }
        else
        {
            var tempColor = iceImage.color;
            tempColor.a = 0f;
            iceImage.color = tempColor;
        }
    }
}
