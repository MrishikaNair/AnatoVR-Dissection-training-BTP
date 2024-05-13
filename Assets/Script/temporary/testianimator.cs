using UnityEngine;
using UnityEngine.XR;

public class testianimator : MonoBehaviour
{
    private Animator muscleAnimator;
    public float hapticIntensity = 0.5f; // Intensity of the haptic feedback
    public LineRenderer scalpelLineRenderer;

    void Start()
    {
        GameObject frognormal = GameObject.Find("FrogStructureH");
        Debug.Log("Animator correct");

        if (frognormal != null)
        {
            // Get the Animator component of the scalpel GameObject
            muscleAnimator = frognormal.GetComponent<Animator>();
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent != null && other.transform.parent.tag == "ModifiedFrog")
        {
            muscleAnimator.SetBool("scalpel_colliding", true);

            
            // Generate haptic feedback when colliding with the modified frog
            //GenerateHapticFeedback(hapticIntensity);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.transform.parent != null && other.transform.parent.tag == "ModifiedFrog")
        {
            scalpelLineRenderer.enabled = false;
            muscleAnimator.SetBool("scalpel_colliding", false);
            
            
        }
    }

    void GenerateHapticFeedback(float intensity)
    {
        // Check if Oculus Touch controllers are connected
        Debug.Log("Vibrate");
      
    }
}
