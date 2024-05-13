using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    public GameObject obj;
    private Animator animator; // Reference to the Animator component
    private bool meshActive = true;

    void Start()
    {
        // Get the Animator component attached to the GameObject
        //animator = GetComponent<Animator>();
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tool")
        {
            // Set the "ToolCollision" trigger in the Animator
            if (animator != null)
            {
               
                animator.SetTrigger("ToolCollision");
            }

            Debug.Log("Pithing start");
        }
    }
}
