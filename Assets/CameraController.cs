using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 lastMousePos;
    float speed = 10;
    // Update is called once per frame
    void Update()
    {
        Vector3 rotationVector = new Vector3(0,0,0);
        rotationVector.y = lastMousePos.z - Input.mousePosition.normalized.z;

        rotationVector.x = lastMousePos.y - Input.mousePosition.normalized.y;

        rotationVector.z=0;

        Debug.Log(rotationVector.y);

        if(Input.GetMouseButton(0))
        transform.Rotate(rotationVector*speed);

        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");
        float yAxis = Input.GetAxis("Ytical");
        transform.position+=new Vector3(xAxis, yAxis, zAxis);
        lastMousePos = Input.mousePosition.normalized;
    }
}
