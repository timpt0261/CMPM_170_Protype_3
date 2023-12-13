using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public GameObject NpcPrefab;
    public float maxNpcs;
    [Range(0, 1)]
    public float initialSpawnPercentage;
    public float spawnBoundsMinX;
    public float spawnBoundsMinY;
    public float spawnBoundsMaxX;
    public float spawnBoundsMaxY;
    public float spawnTime;
    private float lastSpawnTime;
    private List<GameObject> npcs;

    void Start() {
        lastSpawnTime = Time.time;
        npcs = new List<GameObject>();
        for(int i = 0; i < maxNpcs * initialSpawnPercentage; i++) {
            attemptSpawn();
        }
    }

    void Update() {
        float currentTime = Time.time;
        if(currentTime - lastSpawnTime >= spawnTime) {
            attemptSpawn();
        }
    }

    private bool attemptSpawn() {
        lastSpawnTime = Time.time;
        if(npcs.Count >= maxNpcs) return false;
        Vector3 spawnPosition = new Vector3(Random.Range(spawnBoundsMinX, spawnBoundsMaxX), 0f, Random.Range(spawnBoundsMinY, spawnBoundsMaxY));
        GameObject newNpc = Instantiate(NpcPrefab, spawnPosition, Quaternion.identity);
        npcs.Add(newNpc);
        return true;
    }

    public int killNpc(NPCAI npc) {
        npcs.Remove(npc.gameObject);
        Destroy(npc.gameObject);
        return npc.points;
    }
}
