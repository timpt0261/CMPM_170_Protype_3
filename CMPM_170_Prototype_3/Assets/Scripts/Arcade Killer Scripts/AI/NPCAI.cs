using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAI : MonoBehaviour
{
    public NavMeshAgent agent;

    private enum State{ idle, walk, play, die };
    private State state;
    public GameObject Arcade;
    public MeshFilter fovFilter;
    private float timeSinceLastAction;

    void Awake() {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start() {
        state = State.idle;
        timeSinceLastAction = Time.time;
        fovFilter.sharedMesh = FieldOfViewGenerator.GenerateFOVMesh(20, 4, Mathf.PI/2, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.time;
        
        if(currentTime - timeSinceLastAction >= 5) {
            agent.destination = new Vector3(Random.Range(-15, 15), 0f, Random.Range(-15, 15));
            timeSinceLastAction = currentTime;
        }
    }


}
