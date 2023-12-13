using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

class ObstaclePlayer : MonoBehaviour {
    public GameObject brickPrefab, bombPrefab;
    private GameObject selection;

    void Start() {
        selection = null;
    }

    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            place();
        }
    }

    private void place() {
        if(selection == null) return;
        Debug.Log("PLACE");
        Instantiate(selection, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        selection = null;
    }

    public void setBrick() {
        Debug.Log("BRICK");
        selection = brickPrefab;
    }
    public void setBomb() {
        Debug.Log("BOMB");
        selection = bombPrefab;
    }
}
