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
    [SerializeField] private GameObject bullet;
    [SerializeField] private AudioSource pew;
    Vector3 rotateUp = new Vector3(-1, 0, 0);
    Vector3 rotateDown = new Vector3(1, 0, 0);
    Vector3 rotateLeft = new Vector3(0, 1, 0);
    Vector3 rotateRight = new Vector3(0, -1, 0);
    

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
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
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 worldBulletPosition = CursorObj.TransformPoint(new Vector3(0, 0, 0));
            Vector3 directionToCursor = (CursorObj.position - transform.position).normalized;
            pew.Play();
            RaycastHit hit;
            if(Physics.Raycast(worldBulletPosition, directionToCursor, out hit)) {
                GameObject npc = hit.collider.gameObject;
                NPCColliderScript colliderScript = npc.GetComponent<NPCColliderScript>();
                if(colliderScript) {
                    bool wasSeen = colliderScript.isSeen();
                    Debug.Log("Was Seen: " + wasSeen);
                    canvas.GetComponent<HealthBar>().addHealth(FindObjectOfType<Spawner>().killNpc(colliderScript.parent.GetComponent<NPCAI>()));
                    if(wasSeen) canvas.GetComponent<HealthBar>().lose();
                }
            }
        }
    }
    private void CameraMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(rotateUp, camRotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(rotateDown, camRotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(rotateLeft, camRotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(rotateRight, camRotationSpeed * Time.deltaTime);
        }

        Vector3 currentRotation = transform.eulerAngles;
        if(currentRotation.y < 300 && currentRotation.y > 60) {
            float distTo300 = 330 - currentRotation.y;
            float distTo60 = currentRotation.y - 60;
            if(distTo300 < distTo60) {
                currentRotation.y = 300;
            } else {
                currentRotation.y = 60;
            }
        }
        if(currentRotation.x < 330 && currentRotation.x > 30) {
            float distTo330 = 330 - currentRotation.x;
            float distTo30 = currentRotation.x - 30;
            if(distTo330 < distTo30) {
                currentRotation.x = 330;
            } else {
                currentRotation.x = 30;
            }
        }
        Debug.Log(currentRotation);
        currentRotation.z = 0;
        transform.eulerAngles = currentRotation;
    }

    private void UpdateCursor()
    {
        mousePos = Input.mousePosition;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
        canvas.gameObject.transform as RectTransform, mousePos, canvas.worldCamera, out Vector2 localMousePos);
           CursorObj.anchoredPosition = localMousePos;
        
        /*RectTransform cursorRect = CursorObj;
        Vector2 dragMovement = mousePos - previousMousePos;
        cursorRect.anchoredPosition = cursorRect.anchoredPosition + dragMovement;*/
        
        
        

    }
}
