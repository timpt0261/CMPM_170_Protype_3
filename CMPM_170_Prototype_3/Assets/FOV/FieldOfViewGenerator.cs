using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfViewGenerator
{
    public static Mesh GenerateFOVMesh(int numPoints, float radius, float viewAngle, float height) {
        Vector3[] vertices = new Vector3[(numPoints + 1) * 2];
        Vector2[] uv = new Vector2[vertices.Length];
        vertices[0] = Vector3.up * height;
        vertices[vertices.Length/2] = Vector3.zero;
        uv[0] = Vector2.right * 0.5f;
        float rightTriAngle = viewAngle / 2;
        for(int i = 0; i < numPoints; i++) {
            float normalizedSectionIndex = i / (numPoints - 1f);
            float sectionAngle = rightTriAngle * (1 - 2 * normalizedSectionIndex) + Mathf.PI / 2;

            Vector3 pointPos = new Vector3(Mathf.Cos(sectionAngle), 0f, Mathf.Sin(sectionAngle)) * radius;
            vertices[i+1] = pointPos + Vector3.up * height;
            vertices[i+1+vertices.Length/2] = pointPos;
            uv[i+1] = new Vector2(normalizedSectionIndex/0.8f+0.1f, 1f);
        }
        int[] triangles = new int[(numPoints-1)*3 + (numPoints+1)*6];
        for(int i = 0; i < numPoints-1; i++) {
            triangles[i*3] = 0;
            triangles[i*3+1] = i+1;
            triangles[i*3+2] = i+2;
        }

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        return mesh;
    }
}
