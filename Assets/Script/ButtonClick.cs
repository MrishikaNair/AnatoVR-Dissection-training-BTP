using UnityEngine;
using UnityEngine.UI;
using TMPro;
/*
public class ButtonClick : MonoBehaviour
{
    public Pithing pithingScript;
    public Sprite[] tutorialSprites;
    private int currentTutorialStep;
    public TMP_Text tut_cont;

    // Assign the button in the scene to this field in the Unity Editor
    public Button nextButton;

    public string[] stepTexts = {
        "Step 1: Start pithing-Grab the live frog in one hand and needle in the other",
        "Step 2: Insert the needle into the head of the frog",
        "Step 3: Observe the muscular structure of the frog",
        "Step 4: Move the scalpel along the green line to make the incision and separate the muscular structure",
        "Step 5: Use the forceps to grab each fat organ and separate it from the structure",
        "Step 6: Point towards each organ to know the name",
        // Add more step descriptions as needed
    };

    void Start()
    {
        // Start tutorial
        currentTutorialStep = 0;
        ShowNextTutorialStep();

        // Register the button click event
        nextButton.onClick.AddListener(ShowNextTutorialStep);
    }

    void ShowNextTutorialStep()
    {
        // Display the current step's text
        if (currentTutorialStep < stepTexts.Length)
        {
            tut_cont.text = stepTexts[currentTutorialStep];
            currentTutorialStep++;
        }
        else
        {
            // If all steps are shown, activate next script
            ActivateNextScript();
        }
    }

    void ActivateNextScript()
    {
        switch (currentTutorialStep)
        {
            case 1:
                // Activate pithing script
                if (pithingScript != null)
                    pithingScript.enabled = true;
                break;
                // Add cases for activating other scripts
        }
    }
}
*/

