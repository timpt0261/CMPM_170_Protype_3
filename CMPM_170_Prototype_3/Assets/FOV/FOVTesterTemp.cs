using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVTesterTemp : MonoBehaviour
{
    [Range(2, 20)]
    public int numPoints;
    [Range(1, 5)]
    public float radius;
    [Range(0, 180)]
    public float viewAngle;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshFilter>().mesh = FieldOfViewGenerator.GenerateFOVMesh(numPoints, radius, Mathf.Deg2Rad * viewAngle, 0.2f);
    }
}
