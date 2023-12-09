using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Arcade;
    public GameObject HealthBar;
    public float health;

    public float moveSpeed;
    public float groundDrag;
    public bool gameOver = false;
    float verticalInput;
    public Transform orientation;
    float horizontalInput;
    Vector3 moveDirection;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {   
        // health = Arcade.GetComponent<HealthBar>.currentHealth;
        // healthBar.transform.position.x = arcadeGame.transform.position.x;
        // healthBar.transform.position.y = arcadeGame.transform.position.y + 3;
        // healthBar.transform.position.z = arcadeGame.transform.position.z;
        // health follows player wip
        if (health <= 0) {
            gameOver = true;           
        }
        MyInput();
        SpeedControl();

    }

    private void FixedUpdate()
    {
        if (!gameOver) MovePlayer();
    }

    private void MyInput()
    {
        if (!gameOver) 
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
        }
    }

    private void MovePlayer() {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl() {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}
