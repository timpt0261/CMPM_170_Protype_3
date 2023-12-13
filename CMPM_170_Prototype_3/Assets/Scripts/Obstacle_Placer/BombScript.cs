using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float boomTime;
    public GameObject boom;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boomTime = -1f;
        boom.SetActive(false);
        transform.position = new Vector3(transform.position.x, 10f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(boomTime < 0) {
            rb.velocity += Vector2.right * Random.Range(-200f, 200f) * Time.deltaTime;
        } else if(Time.time - boomTime > 0.5) {
            Destroy(gameObject);
        }
    }
    void myMainGo() {
        if(boomTime < 0) {
            CircleCollider2D boomTrigger = gameObject.AddComponent<CircleCollider2D>();
            boomTrigger.radius = 3f;
            boomTrigger.isTrigger = true;
            boomTime = Time.time;
            rb.gravityScale = 0;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            boom.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        AI_Movement playerComp = collider.gameObject.GetComponent<AI_Movement>();
        if(playerComp) {
            playerComp.damage();
        }
    }
    void OnCollisionEnter2D(Collision2D collision) {
        myMainGo();
    }
}
