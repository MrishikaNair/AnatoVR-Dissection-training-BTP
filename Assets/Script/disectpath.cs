using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disectpath : MonoBehaviour
{
    // Define waypoints or checkpoints along the path
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;

    // Reference to the Line Renderer component
    private LineRenderer lineRenderer;

    // Reference to the Animator component
    //private Animator animator;
    

    private void Start()
    {
        // Get the Line Renderer component attached to this GameObject
        lineRenderer = GetComponent<LineRenderer>();

        // Set the number of positions in the Line Renderer to match the number of waypoints
        lineRenderer.positionCount = waypoints.Length;

        // Get the Animator component attached to the GameObject controlling the animation
        /*
        animator = transform.parent.GetComponent<Animator>();
        animator.SetBool("collision of scalpel", false);*/
    }

    private void Update()
    {
        // Update the positions of the Line Renderer to match the positions of the waypoints
        for (int i = 0; i < waypoints.Length; i++)
        {
            lineRenderer.SetPosition(i, waypoints[i].position);
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "tool")
        {
            // Check if the collision occurs along the defined path
            if (IsCollisionOnPath())
            {
                Debug.Log("hoho disection is on path");

                // Turn off the collided organ
                //other.gameObject.SetActive(false);
            }
        }
        /*
        // Check if the collided object is a child of the body
        if (other.transform.parent != null && other.transform.gameObject.tag == "disection")
        {
            // Check if the collision occurs along the defined path
            if (IsCollisionOnPath())
            {
                // Trigger the animation
                //animator.SetTrigger("dissection_path");

                Debug.Log("LOLMRISH");
                //animator.SetBool("collision of scalpel", true);
                // Turn off the collided organ

                other.gameObject.SetActive(false);
            }
        }*/
    }

    private bool IsCollisionOnPath()
    {
        // Check if the distance between the scalpel and the current waypoint is within a threshold
        float distanceToWaypoint = Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position);
        if (distanceToWaypoint < 0.1f) // Adjust the threshold as needed
        {
            // Move to the next waypoint
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                // Reached the end of the path
                return true; // Return true if the collision occurs along the defined path
            }
        }
        return false;
    }
}

