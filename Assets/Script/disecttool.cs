using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disecttool : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is a child of the body
        if (other.transform.parent != null && other.transform.gameObject.tag == "disection")
        {
            
            // Turn off the collided organ
            other.gameObject.SetActive(false);
        }
    }
}
