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
    private float timeSinceLastAction;
    private float waitTime;
    public Vector2 waitTimeRange;
    public GameObject fovObject;

    void Awake() {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        state = State.idle;
        getNextDestination();
        fovObject.GetComponent<MeshFilter>().sharedMesh = FieldOfViewGenerator.GenerateFOVMesh(20, 5f, Mathf.PI/2, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.time;
        if(currentTime - timeSinceLastAction >= waitTime) {
            getNextDestination();
        }
    }

    private void getNextDestination() {
        waitTime = Random.Range(waitTimeRange.x, waitTimeRange.y);
        timeSinceLastAction = Time.time;
        agent.destination = randomDestination(-15, -15, 15, 15);
    }

    private Vector3 randomDestination(float minX, float minY, float maxX, float maxY) {
        return new Vector3(Random.Range(minX, maxX), 0f, Random.Range(minY, maxY));
    }

}
