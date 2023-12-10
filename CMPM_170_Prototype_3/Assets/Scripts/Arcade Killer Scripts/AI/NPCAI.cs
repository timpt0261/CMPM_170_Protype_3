using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAI : MonoBehaviour
{
    public NavMeshAgent agent;

    private enum State{ idle, walk, play, die };
    private State state;
    float current, rot;
    public float Speed, h, v;
    public GameObject Arcade;

    void Start()
    {
        state = State.idle;
        current = 0;
        Speed = 10f;
        h = 0f; v = 0.01f;
        //Debug.Log((int)state);
    }

    // Update is called once per frame
    void Update()
    {
        current += Time.deltaTime;

        if(current > 1)
        {
            state = (State)Random.Range(0, 2);
            current = 0;
        }

        if (transform.rotation.y < 0) {
            rot = 360 + transform.eulerAngles.y;
        }
        else
        {
            rot = transform.eulerAngles.y;
        }

        if (state == State.walk)
        {
            if (
                (transform.position.x > 17 && rot < 180 && rot > 0) || 
                (transform.position.x < -17 && rot > 180 && rot < 360) || 
                (transform.position.z > 17 && (rot < 90 || rot > 270)) || 
                (transform.position.z < -17 && rot > 90 && rot < 270)
                )
            {
                Speed = 0f;
                state = State.idle;
            }
            else
            {
                Speed = 10f;
            }
            transform.Translate(new Vector3 (0, 0, Speed * Time.deltaTime));
            Debug.Log(state);
        }
        if(state == State.idle)
        {
            transform.Rotate(new Vector3(0, 20f * Time.deltaTime, 0));
            Debug.Log(state);

        }
        if(state == State.play)
        {
            Debug.Log((int)state);
        }
    }


}
