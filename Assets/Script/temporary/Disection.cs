using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disection : MonoBehaviour
{
    /*
    public GameObject A;
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is on the "Disection" layer
        if (collision.gameObject.layer == LayerMask.NameToLayer("disection"))
        {
            // Set the collided object's active state to false
            collision.gameObject.SetActive(false);
        }
    }
    */
    public GameObject muscleLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // OnCollisionEnter is called when a collision occurs
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is the scalpel
        if (collision.gameObject.CompareTag("Tool"))
        {
            Debug.Log("touch ho rha hai");
            // Deactivate the muscle layer
            muscleLayer.SetActive(false);
        }
    }
}
