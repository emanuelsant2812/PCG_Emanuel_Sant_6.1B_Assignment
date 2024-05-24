using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground: MonoBehaviour
{
    void Start()
    {   // Create a plane primitive and name it "LargePlane"
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane.name = "Plane";

        // Set the plane as a child of the current GameObject
        plane.transform.SetParent(transform);

        // Set the local position of the plane to (0, 0, 0) relative to its parent
        plane.transform.localPosition = Vector3.zero;

        // Scale the plane to make it very large
        plane.transform.localScale = new Vector3(3000, 1, 3000);

        // Optionally, set the material of the MeshRenderer if you want to customize its appearance
        MeshRenderer meshRenderer = plane.GetComponent<MeshRenderer>();
        meshRenderer.material = new Material(Shader.Find("Standard"));

        // Optionally, customize the material's color
        meshRenderer.material.color = Color.green;
    }
}
