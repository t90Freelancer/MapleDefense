using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveToBoss : MonoBehaviour
{
    public float speed;
    [SerializeField] private Transform target;
    public void MovePosition()
    {
        transform.position = Vector3.Lerp(transform.position,target.position,speed*Time.deltaTime);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            MovePosition();
        }
    }
}
