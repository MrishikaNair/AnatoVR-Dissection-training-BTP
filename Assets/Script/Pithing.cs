using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pithing : MonoBehaviour
{
    private Animator animator;
    public GameObject frogStructureH;
    
    public GameObject frogfirst1;

    void Start()
    {
        GameObject frogfirst = GameObject.Find("FrogSkin");

        if (frogfirst != null)
        {
            // Get the Animator component of the scalpel GameObject
            animator = frogfirst.GetComponent<Animator>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Pithing ho rhi hai");
        if (other.gameObject.tag == "Tool")
        {
            animator.SetBool("IsPithing", true);
        }

        // Invoke the ActivateFrogStructureH method after 5 seconds
        Invoke("ActivateFrogStructureH", 5f);
    }

    // Method to activate frogStructureH and deactivate frogfirst1
    private void ActivateFrogStructureH()
    {
        if (frogStructureH != null)
        {
            frogStructureH.SetActive(true);
        }
        else
        {
            Debug.LogError("FrogStructureH reference not set!");
        }

        // Invoke the DeactivateFrogFirst1 method after 2 seconds
        Invoke("DeactivateFrogFirst1", 0f);
    }

    // Method to deactivate frogfirst1
    private void DeactivateFrogFirst1()
    {
        if (frogfirst1 != null)
        {
            frogfirst1.SetActive(false);
        }
        else
        {
            Debug.LogError("FrogFirst1 reference not set!");
        }
    }
}

