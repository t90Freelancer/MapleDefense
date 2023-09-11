using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float panSpeed = 4f;
       
 
    private void ControllCamera()
    {
        Vector3 pos = transform.position;     
       
        if (Input.GetKey(KeyCode.D))
        {
            if (pos.x < 10f) { 
               pos.x += panSpeed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (pos.x >-8.61f) { 
            pos.x -= panSpeed * Time.deltaTime;
            }
        }
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        ControllCamera();
    }
}
