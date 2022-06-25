using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;

    public Vector2 minPosition;
    public Vector2 maxPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void LateUpdate()
    {
        if(target != null)
        {
            if (transform.position != target.position)
            {
                Vector3 desiredPosition = target.position;
                desiredPosition.x = Mathf.Clamp(desiredPosition.x, minPosition.x, maxPosition.x);
                desiredPosition.y = Mathf.Clamp(desiredPosition.y, minPosition.y, maxPosition.y);
                transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            }
        }
    }

    public void SetCamPosLimit(Vector2 minPos, Vector2 maxPos)
    {
        minPosition = minPos;
        maxPosition = maxPos;
    }
}
