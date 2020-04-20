using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showtutorial : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject playbutton;
    public GameObject tutorialbutton;
    // Start is called before the first frame update
    void Start()
    {
        tutorial.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void ToggleTutorial() {
        if (tutorial.activeSelf)
        {
            tutorialtextcontroller.resetcurrent(); 
            tutorial.SetActive(false);
            playbutton.SetActive(true);
            tutorialbutton.SetActive(true); 
        }
        else if (!tutorial.activeSelf) {
            tutorial.SetActive(true);
            playbutton.SetActive(false);
            tutorialbutton.SetActive(false); 
        }
    }
}
