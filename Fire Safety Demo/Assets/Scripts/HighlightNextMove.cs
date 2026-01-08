using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightNextMove : MonoBehaviour
{
    public Transform[] NavPoints;
    public Camera cam;
    public GameObject arrowViz;

    public void ShowNextPoint(int id)
    {
        ShowArrow();
        transform.position = NavPoints[id].position;
    }

    public void ShowArrow()
    {
        arrowViz.SetActive(true);
    }
    public void HideArrow()
    {
        arrowViz.SetActive(false);
    }

    void Update()
    {
        // Get the direction from the object to the camera
        Vector3 directionToCamera = Camera.main.transform.position - transform.position;

        // Flatten the direction vector to the XZ plane (ignore Y component)
        directionToCamera.y = 0f;

        // Calculate the rotation needed to look along the flattened direction
        // The default up vector (Vector3.up) works well for standard XZ plane games
        Quaternion targetRotation = Quaternion.LookRotation(directionToCamera, Vector3.up);

        // Apply the new rotation
        transform.rotation = targetRotation;
    }
}
