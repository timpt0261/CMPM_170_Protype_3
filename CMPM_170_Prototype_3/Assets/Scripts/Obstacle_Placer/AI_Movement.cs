using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AI_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float normalSpeed, closeSpeed, closeDist, jumpDist, jumpHeight, gravity;
    public LayerMask rayMask;

    private float jumpSpeed;
    private Rigidbody2D rb;
    private bool jumping;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpSpeed = Mathf.Sqrt(2 * gravity * jumpHeight);
        jumping = false;
    }

    void FixedUpdate()
    {
        if(!isGrounded()) {
            if(jumping && rb.velocity.y <= 0) {
                jumping = false;
            }
            rb.velocity += Vector2.down * gravity * Time.deltaTime;
        } else {
            if(Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), jumpDist, rayMask) && !jumping) {
                jump();
            }
        }
        float speed = Physics2D.Raycast(transform.position + Vector3.right * 0.51f, transform.TransformDirection(Vector2.right), closeDist, rayMask) ? closeSpeed : normalSpeed;
        if (Physics2D.Raycast(transform.position + Vector3.right * 0.51f, transform.TransformDirection(Vector2.right), 0.01f, rayMask)) {
            speed = 0;
        }
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    private void jump() {
        jumping = true;
        rb.velocity += Vector2.up * jumpSpeed;
    }

    private bool isGrounded() {
        return Physics2D.Raycast(transform.position + Vector3.down * 0.51f, transform.TransformDirection(Vector2.down), 0.1f, rayMask);
    }

    public void damage() {
        Debug.Log("Damage");
        SceneManager.LoadScene(5);
    }
    public void goal() {
        SceneManager.LoadScene(1);
    }
}
