using UnityEngine;

public class disectpath_try : MonoBehaviour
{
    // Define waypoints or checkpoints along the path
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;

    // Reference to the Line Renderer component
    private LineRenderer lineRenderer;

    // Reference to the Animator component
    private Animator frogAnimator;

    private void Start()
    {
        // Get the Line Renderer component attached to this GameObject
        lineRenderer = GetComponent<LineRenderer>();

        // Set the number of positions in the Line Renderer to match the number of waypoints
        lineRenderer.positionCount = waypoints.Length;

        // Set the positions of the Line Renderer to match the positions of the waypoints
        for (int i = 0; i < waypoints.Length; i++)
        {
            lineRenderer.SetPosition(i, waypoints[i].position);
        }

        // Get the Animator component attached to the GameObject controlling the animation
        GameObject frogObject = GameObject.Find("FrogStructure");

        // Get the Animator component attached to the frog GameObject
        if (frogObject != null)
        {
            Debug.Log("Frog object found: " + frogObject.name);
            frogAnimator = frogObject.GetComponent<Animator>();
        }
        

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.parent != null && other.transform.parent.tag == "Back_frog")
        {
            Debug.Log("Back frog animator tigger");
            frogAnimator.SetBool("Scalpel_colliding", true);
        }
        if (Input.GetKey(KeyCode.B))
        {
            frogAnimator.SetBool("Scalpel_colliding", false);

            //imator.SetBool("reset_pressed", true);
        }


       // frogAnimator.SetBool("Scalpel_colliding", true);
        
        /*
        // Check if the collided object is a child of the body
        if (other.transform.parent != null && other.transform.gameObject.tag == "dissection")
        {
            // Check if the collision occurs along the defined path
            if (IsCollisionOnPath())
            {
                frogAnimator.SetBool("Scalpel_colliding", true);
                // Turn off the collided organ
                //other.gameObject.SetActive(false);
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
        return true;
    }
}
