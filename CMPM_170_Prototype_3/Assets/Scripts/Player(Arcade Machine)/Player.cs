using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float camRotationSpeed = 10.0f;
    public float bulletSpeed = 20.0f;
    [SerializeField]
    private GameObject bullet;
    Vector3 rotateUp = new Vector3(-1, 0, 0);
    Vector3 rotateDown = new Vector3(1, 0, 0);
    Vector3 rotateLeft = new Vector3(0, 1, 0);
    Vector3 rotateRight = new Vector3(0, -1, 0);

    private void Start()
    {
        
    }
    private void Update()
    {
        CameraMovement();
        ShootMoment();

    }
    private void ShootMoment()
    {
        //We want a projectile to come out
        if(Input.GetMouseButtonDown(0))
        {
            int transformYModifier = 20;
            Vector3 BulletPostion = new Vector3(transform.position.x, transform.position.y - transformYModifier, transform.position.z);
            GameObject bulletInstance = Instantiate(bullet, transform.position, transform.rotation);
            Rigidbody bulletRb = bulletInstance.GetComponent<Rigidbody>();
            bulletRb.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
            
        }
    }
    private void CameraMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(rotateUp, camRotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(rotateDown, camRotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(rotateLeft, camRotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(rotateRight, camRotationSpeed * Time.deltaTime);
        }

        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.z = 0;
        transform.eulerAngles = currentRotation;
    }
}
