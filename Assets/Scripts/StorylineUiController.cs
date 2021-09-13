using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StorylineUiController : MonoBehaviour
{
    [SerializeField] private Text textbox;

    private string[] storyLines = {
        "Your kids will arrive from school in a couple of minutes, you have to prepare for dinner, but there’s a huge problem. The house is a mess and various kitchen items needed for food preparation are scattered in different locations inside the house.",
        "Look for the following items that are essential for food preparation before the sun sets down. A checklist will be given as a guide in finding the said items which can be toggled by pressing 'C'. Good luck and hurry!"
    };

    private int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        textbox.text = storyLines[0];
        //i++;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void nextLine()
    {
        i++;
        if (i >= storyLines.Length)
        {
            SceneManager.LoadScene("Storyline3");
        }
        else
        {
            textbox.text = storyLines[1];
        }
    }
}
