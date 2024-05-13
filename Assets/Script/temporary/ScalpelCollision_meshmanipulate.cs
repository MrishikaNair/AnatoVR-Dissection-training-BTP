using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalpelCollision_meshmanipulate : MonoBehaviour
{
    public GameObject muscleLayerObject; // Reference to the GameObject containing the muscle layer
    public Mesh newMuscleMesh; // The new mesh for the muscle layer

    private bool hasCollided = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collision is with a GameObject tagged as "Scalpel" and if it hasn't collided yet
        if (other.CompareTag("Scalpel") && !hasCollided)
        {
            Debug.Log("Scalpel collided with frog - manipulating muscle layer.");

            // Get the mesh renderer component of the muscle layer GameObject
            MeshFilter muscleMeshFilter = muscleLayerObject.GetComponent<MeshFilter>();

            if (muscleMeshFilter != null && newMuscleMesh != null)
            {
                // Assign the new mesh to the muscle layer
                muscleMeshFilter.mesh = newMuscleMesh;
                Debug.Log("Muscle layer mesh replaced.");
            }
            else
            {
                Debug.LogError("Muscle mesh filter or new muscle mesh is not assigned.");
            }

            hasCollided = true; // Set collision flag to true
        }
    }
}
