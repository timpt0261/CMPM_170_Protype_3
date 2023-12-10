using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public float rotationSpeed = 10.0f;
    Vector3 rotateUp = new Vector3(-1, 0, 0);
    Vector3 rotateDown = new Vector3(1, 0, 0);
    Vector3 rotateLeft = new Vector3(0, -1, 0);
    Vector3 rotateRight = new Vector3(0, 1, 0);

    private void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            
            transform.Rotate(rotateUp, rotationSpeed * Time.deltaTime);
        } 
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(rotateDown, rotationSpeed * Time.deltaTime);
            Debug.Log("hello");
        } else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(rotateLeft, rotationSpeed * Time.deltaTime);
        } else if ( Input.GetKey(KeyCode.A))
        {
            transform.Rotate(rotateRight, rotationSpeed * Time.deltaTime);
        }
    }
}
