using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float camRotationSpeed = 10.0f;
    public float bulletSpeed = 20.0f;
    public float mouseMoveSpeed = 0.1f;
    Vector3 mousePos;
    [SerializeField] private RectTransform CursorObj;
    [SerializeField] private Canvas canvas;
    [SerializeField]
    private GameObject bullet;
    Vector3 rotateUp = new Vector3(-1, 0, 0);
    Vector3 rotateDown = new Vector3(1, 0, 0);
    Vector3 rotateLeft = new Vector3(0, 1, 0);
    Vector3 rotateRight = new Vector3(0, -1, 0);
    Vector3 previousMousePos;

    private void Start()
    {
        Cursor.visible = false;
        previousMousePos = Mouse.current.position.ReadValue();

    }
    private void Update()
    {
        CameraMovement();
        
        
        UpdateCursor();

        ShootMoment();

    }
    private void ShootMoment()
    {
        //We want a projectile to come out
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
           
            Vector3 worldBulletPosition = CursorObj.TransformPoint(new Vector3(0, 0, 0));
            Vector3 directionToCursor = (CursorObj.position - transform.position).normalized;
            GameObject bulletInstance = Instantiate(bullet, worldBulletPosition, Quaternion.LookRotation(directionToCursor));
            
            Rigidbody bulletRb = bulletInstance.GetComponent<Rigidbody>();
            bulletRb.AddForce(directionToCursor * bulletSpeed, ForceMode.Impulse);
            
        }
    }
    private void CameraMovement()
    {
        var keyboard = Keyboard.current;
        if (keyboard.wKey.isPressed)
        {
            transform.Rotate(rotateUp, camRotationSpeed * Time.deltaTime);
        }
        else if (keyboard.sKey.isPressed)
        {
            transform.Rotate(rotateDown, camRotationSpeed * Time.deltaTime);
        }
        else if (keyboard.dKey.isPressed)
        {
            transform.Rotate(rotateLeft, camRotationSpeed * Time.deltaTime);
        }
        else if (keyboard.aKey.isPressed)
        {
            transform.Rotate(rotateRight, camRotationSpeed * Time.deltaTime);
        }

        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.z = 0;
        transform.eulerAngles = currentRotation;
    }

    private void UpdateCursor()
    {
        mousePos = Mouse.current.position.ReadValue();

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
        canvas.gameObject.transform as RectTransform, mousePos, canvas.worldCamera, out Vector2 localMousePos);
           CursorObj.anchoredPosition = localMousePos;
        
        /*RectTransform cursorRect = CursorObj;
        Vector2 dragMovement = mousePos - previousMousePos;
        cursorRect.anchoredPosition = cursorRect.anchoredPosition + dragMovement;*/
        
        
        

    }
}
