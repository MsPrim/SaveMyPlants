//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class SkipButton : MonoBehaviour
{
    public GameObject cutsceneObject; // Reference to the cutscene object
    public Button skipButton; // Reference to the UI Button

    // Start is called before the first frame update
    void Start()
    {
        if (skipButton != null)
        {
            skipButton.onClick.AddListener(SkipCutscene);
        }
    }

    void SkipCutscene()
    {
        // Hide or disable the cutscene
        if (cutsceneObject != null)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
