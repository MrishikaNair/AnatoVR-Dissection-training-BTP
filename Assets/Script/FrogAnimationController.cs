using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogAnimationController : MonoBehaviour
{
    private Animator frogAnimator;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Animator component attached to the frog
        frogAnimator = GetComponent<Animator>();
    }

    // OnTriggerEnter is called when a Collider enters the trigger
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the needle object
        if (other.CompareTag("Tool"))
        {
            // Change the weight of the base layer to 0 and the weight of cheek1 layer to 1
            frogAnimator.SetLayerWeight(0, 0f);
            frogAnimator.SetLayerWeight(1, 1f);
            Debug.Log("Animation should change");
        }
    }
}
