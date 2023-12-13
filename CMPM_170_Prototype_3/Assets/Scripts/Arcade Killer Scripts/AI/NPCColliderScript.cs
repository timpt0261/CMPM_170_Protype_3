using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCColliderScript : MonoBehaviour
{
    public int seenCount;
    public GameObject parent;

    void Start() {
        seenCount = 0;
    }

    public bool isSeen() {
        return seenCount > 0;
    }
}
