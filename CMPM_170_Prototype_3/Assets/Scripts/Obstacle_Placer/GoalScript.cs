using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("GOAL ENTER");
        AI_Movement playerComp = collider.gameObject.GetComponent<AI_Movement>();
        if(playerComp) {
            playerComp.goal();
        }
    }

}
