using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Organ_grab : MonoBehaviour
{
    private bool canGrab = false;
    public XRGrabInteractable grabInteractable;
    private Animator muscleAnimator;
    private Animator muscleAnimator1;
    private Animator muscleAnimator2;
    private Animator muscleAnimator3;
    int fatt = 0;
    int sptum = 0;
    int org_no = 0;
    public Dictionary<string, Animator> animators = new Dictionary<string, Animator>();

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject != null && other.gameObject.CompareTag("fat"))
        {
            // Adjust the position of the collided object
            /*
            Vector3 newPosition = other.transform.position;
            newPosition.z += 0.6f; // Subtract 4 from the x coordinate
            other.transform.position = newPosition;

            Debug.Log("Fat object collided with the sphere.");
            //canGrab = true;
            grabInteractable.enabled = true;*/
            GameObject fat = GameObject.Find("fat");
            if (fat != null)
            {
                // Get the Animator component of the scalpel GameObject
                muscleAnimator = fat.GetComponent<Animator>();
            }
            muscleAnimator.SetBool("fat_coll", true);
            GameObject fat1 = GameObject.Find("fat 1");
            if (fat1 != null)
            {
                // Get the Animator component of the scalpel GameObject
                muscleAnimator = fat1.GetComponent<Animator>();
            }
            muscleAnimator.SetBool("fat1_coll", true);

            fatt = 1;
        }

        if (other.gameObject != null && other.gameObject.CompareTag("septum") && fatt == 1)
        {
            yield return new WaitForSeconds(1f);
            GameObject sternum = GameObject.Find("Pectoral girdle");
            if (sternum != null)
            {
                // Get the Animator component of the scalpel GameObject
                muscleAnimator = sternum.GetComponent<Animator>();
            }
            muscleAnimator.SetBool("Sptum_collision", true);
            sptum = 1;


        }
        
        if(sptum==1)
        {
            //Invoke("CheckOtherCollisions", 1f);
            yield return new WaitForSeconds(1f);
            CheckOtherCollisions(other);
        }
    }

    public void CheckOtherCollisions(Collider other)
    {

        if (other.gameObject != null && other.gameObject.CompareTag("sclera"))
        {
            GameObject org1 = GameObject.Find("sclera");
            GameObject org = GameObject.Find("olfactory lobe");
            GameObject org3 = GameObject.Find("Olfactory lobe 1");
            GameObject org2 = GameObject.Find("brain");
            if (org1 != null)
            {
                // Get the Animator component of the scalpel GameObject
                muscleAnimator = org1.GetComponent<Animator>();
                muscleAnimator1 = org.GetComponent<Animator>();
                muscleAnimator2 = org2.GetComponent<Animator>();
                muscleAnimator3 = org3.GetComponent<Animator>();
            }
            muscleAnimator.SetBool("sclera_collision", true);
            muscleAnimator1.SetBool("Olfact_collision", true);
            muscleAnimator2.SetBool("brain_collision", true);
            muscleAnimator3.SetBool("olfact1_collision", true);

            /*          
         AudioSource audioSource = org.GetComponent<AudioSource>();
         if (audioSource != null)
         {
             audioSource.enabled = true;
             audioSource.Play();
             yield return new WaitForSeconds(audioSource.clip.length);
             Debug.Log("Lengthhhhhhhhhhhh");
            Debug.Log(audioSource.clip.length);
             audioSource.enabled = false;
         }*/
        }
        /*
        if (other.gameObject != null && other.gameObject.CompareTag("olfact1"))
        {
            GameObject org = GameObject.Find("Olfactory lobe 1");
            if (org != null)
            {
                // Get the Animator component of the scalpel GameObject
                muscleAnimator = org.GetComponent<Animator>();
            }
            muscleAnimator.SetBool("olfact1_collision", true);
           
        }
        
        if (other.gameObject != null && other.gameObject.CompareTag("brain"))
        {
            GameObject org = GameObject.Find("brain");
            if (org != null)
            {
                // Get the Animator component of the scalpel GameObject
                muscleAnimator = org.GetComponent<Animator>();
            }
            muscleAnimator.SetBool("brain_collision", true);
            
        }
        if (other.gameObject != null && other.gameObject.CompareTag("sclera"))
        {
            GameObject org = GameObject.Find("sclera");
            if (org != null)
            {
                // Get the Animator component of the scalpel GameObject
                muscleAnimator = org.GetComponent<Animator>();
            }
            muscleAnimator.SetBool("sclera_collision", true);
            
        }*/
        if (other.gameObject != null && other.gameObject.CompareTag("heart"))
        {
            GameObject org = GameObject.Find("heart123");
            if (org != null)
            {
                // Get the Animator component of the scalpel GameObject
                muscleAnimator = org.GetComponent<Animator>();
            }
            muscleAnimator.SetBool("heart_collision", true);
            
        }
        if (other.gameObject != null && other.gameObject.CompareTag("testis"))
        {
            GameObject org = GameObject.Find("testis");
            if (org != null)
            {
                // Get the Animator component of the scalpel GameObject
                muscleAnimator = org.GetComponent<Animator>();
            }
            muscleAnimator.SetBool("testis_collision", true);
            
        }
        if (other.gameObject != null && other.gameObject.CompareTag("stomach"))
        {
            GameObject org = GameObject.Find("stomach");
            if (org != null)
            {
                // Get the Animator component of the scalpel GameObject
                muscleAnimator = org.GetComponent<Animator>();
            }
            muscleAnimator.SetBool("stomach_collision", true);
            
        }
        if (other.gameObject != null && other.gameObject.CompareTag("lung"))
        {
            GameObject org = GameObject.Find("lung");
            if (org != null)
            {
                // Get the Animator component of the scalpel GameObject
                muscleAnimator = org.GetComponent<Animator>();
            }
            muscleAnimator.SetBool("lung_collision", true);
            
        }
        if (other.gameObject != null && other.gameObject.CompareTag("lung1"))
        {
            GameObject org = GameObject.Find("lung 1");
            if (org != null)
            {
                // Get the Animator component of the scalpel GameObject
                muscleAnimator = org.GetComponent<Animator>();
            }
            muscleAnimator.SetBool("lung1_collision", true);
            
        }
        if (other.gameObject != null && other.gameObject.CompareTag("kid"))
        {
            GameObject org = GameObject.Find("kidney");
            if (org != null)
            {
                // Get the Animator component of the scalpel GameObject
                muscleAnimator = org.GetComponent<Animator>();
            }
            muscleAnimator.SetBool("kid_collision", true);
            
        }
        if (other.gameObject != null && other.gameObject.CompareTag("kid1"))
        {
            GameObject org = GameObject.Find("kidney 1");
            if (org != null)
            {
                // Get the Animator component of the scalpel GameObject
                muscleAnimator = org.GetComponent<Animator>();
            }
            muscleAnimator.SetBool("kid1_collision", true);
            
        }
        if (other.gameObject != null && other.gameObject.CompareTag("gall"))
        {
            GameObject org = GameObject.Find("gallbladder");
            if (org != null)
            {
                // Get the Animator component of the scalpel GameObject
                muscleAnimator = org.GetComponent<Animator>();
            }
            muscleAnimator.SetBool("gall_collision", true);
            
        }
        if (other.gameObject != null && other.gameObject.CompareTag("pan"))
        {
            GameObject org = GameObject.Find("pancreas");
            if (org != null)
            {
                // Get the Animator component of the scalpel GameObject
                muscleAnimator = org.GetComponent<Animator>();
            }
            muscleAnimator.SetBool("pan_collision", true);
            
        }
        if (other.gameObject != null && other.gameObject.CompareTag("blad"))
        {
            GameObject org = GameObject.Find("bladder");
            if (org != null)
            {
                // Get the Animator component of the scalpel GameObject
                muscleAnimator = org.GetComponent<Animator>();
            }
            muscleAnimator.SetBool("blad_collision", true);
            
        }
        if (other.transform.parent != null && other.transform.parent.tag == "haslet")
        {
            GameObject org = GameObject.Find("Haslet");
            if (org != null)
            {
                // Get the Animator component of the scalpel GameObject
                muscleAnimator = org.GetComponent<Animator>();
            }
            muscleAnimator.SetBool("liver_collision", true);
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Cylinder left the fat object");
        //canGrab = false;
    }
}


