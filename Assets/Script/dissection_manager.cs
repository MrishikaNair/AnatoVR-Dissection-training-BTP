using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DissectionManager : MonoBehaviour
{
    public Pithing pithingScript;
    public Sprite[] tutorialSprites;
    private int currentTutorialStep;
    public TMP_Text tut_cont;
    public Button nextButton;
    public Button prevButton;
    public AudioClip[] stepAudioClips; // Array to hold audio clips for each step
    private AudioSource audioSource;

    public testianimator testAnimator;

    public string[] stepTexts = {
        "Welcome to AnatoVR, through this training we will help you learn and practice frog dissection",
        "Step 1: Start pithing-Grab the live frog in left hand and needle in the right hand",
        "Step 2: Insert the needle into the head of the frog",
        "Step 3: After imobilisation of the frog, its is placed ventral side up on the middle tray",
        "Step 4: Observe the muscular structure of the frog",
        "Step 5: Grab the scalpel and  move it along the H-shaped green line to make the incision and separate the muscular structure",
        "Step 6: Pick up the forceps, and then locate the fat bodies - spaghetti like structures along the abdominal wall",
        "Step 7: Use the forceps to grab each fat organ and separate it from the structure",
        "Step 8: Use the forceps to seperate the spetum bone, which is a part of the rib cage",
        "Step 9: Using the forceps pickup the other organs, and follow the animation to see their names on the organ chart",
        "Congratulations you have completed the training"
        //Add more step descriptions as needed
    };

    void Start()
    {
        GameObject frognormal = GameObject.Find("FrogStructureH");
        audioSource = GetComponent<AudioSource>();
        frognormal.SetActive(false);
        currentTutorialStep = 0;
        ShowTutorialStep(currentTutorialStep);
       
        audioSource = GetComponent<AudioSource>(); // Get AudioSource component

        // Add listeners to the buttons
        nextButton.onClick.AddListener(ShowNextTutorialStep);
        prevButton.onClick.AddListener(ShowPreviousTutorialStep);
    }

    public void ShowNextTutorialStep()
    {
        if (currentTutorialStep < stepTexts.Length - 1)
        {
            currentTutorialStep++;
            ShowTutorialStep(currentTutorialStep);
        }
    }

    public void ShowPreviousTutorialStep()
    {
        if (currentTutorialStep > 0)
        {
            currentTutorialStep--;
            ShowTutorialStep(currentTutorialStep);
        }
    }

    void ShowTutorialStep(int stepIndex)
    {
        tut_cont.text = stepTexts[stepIndex];
        Debug.Log(stepAudioClips.Length);
        
        if (stepIndex < stepAudioClips.Length)
        {
            audioSource.clip = stepAudioClips[stepIndex];
            audioSource.Play();
        }
        if (stepIndex >= stepTexts.Length - 1)
        {
            ActivateNextScript();
        }
        // Play audio clip for the current step
        
        
    }

    void ActivateNextScript()
    {
        switch (currentTutorialStep)
        {
            case 1:
                // Activate the pithing script
                if (pithingScript != null)
                {
                    pithingScript.enabled = true;
                }
                break;

            case 3:
                // Activate the frognormal GameObject
                GameObject frognormal1 = GameObject.Find("FrogStructureH");
                if (frognormal1 != null)
                {
                    Debug.Log("meh active");
                    frognormal1.SetActive(true);
                }
                break;
        }
    }

    // Other methods, if any...
}
