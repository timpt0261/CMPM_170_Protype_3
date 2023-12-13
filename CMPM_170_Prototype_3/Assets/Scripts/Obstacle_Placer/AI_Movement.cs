using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Rigidbody2D rb;

    private float distance;

    void Start()
    {
        rb.velocity = new Vector2(10.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D close = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 20f);
        RaycastHit2D jump = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 5f);
    
        if (close) {
            rb.velocity += new Vector2(1f, 0.0f);
        }

        if (jump) {
            rb.AddForce(new Vector2(rb.velocity.x, speed));
            rb.velocity = new Vector2(10.0f, 0.0f);
        }
    }

    void FixedUpdate()
    {

    }
}
