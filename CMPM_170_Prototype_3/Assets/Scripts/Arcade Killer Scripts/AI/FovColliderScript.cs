using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FovColliderScript : MonoBehaviour
{
    public MeshCollider myCollider;

    void OnTriggerEnter(Collider collider) {
        if(collider.Equals(myCollider)) return;
        if(collider.gameObject.tag == "npc") {
            collider.gameObject.GetComponent<NPCColliderScript>().seenCount++;
        }
    }
    void OnTriggerExit(Collider collider) {
        if(collider.Equals(myCollider)) return;
        if(collider.gameObject.tag == "npc") {
            collider.gameObject.GetComponent<NPCColliderScript>().seenCount--;
        }
    }
}
