using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    private float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        spawnTime = Time.time;
    }

    void Update() {
        if(Time.time - spawnTime > 3) {
            Destroy(gameObject);
        }
    }
}
