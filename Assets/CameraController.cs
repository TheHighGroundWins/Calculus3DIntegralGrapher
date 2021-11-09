using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 lastMousePos;
    const float speed = 5;

    // Update is called once per frame
    void Update()
    {



        if (Input.GetMouseButton(0))
        {
            transform.Rotate(speed * new Vector3(Input.GetAxis("Mouse Y")*-1, Input.GetAxis("Mouse X"), 0));
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,0);
        }

        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");
        float yAxis = Input.GetAxis("Ytical");
        transform.position += new Vector3(xAxis, yAxis, zAxis);
    }
}
