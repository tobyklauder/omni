using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showtutorial : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject credits; 
    public GameObject playbutton;
    public GameObject text; 
    public bool showing = false; 
    // Start is called before the first frame update
    void Start()
    {
        tutorial.SetActive(false);
        credits.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && credits.activeSelf == false) {
            if (tutorial.activeSelf)
            {
                tutorial.SetActive(false);
                playbutton.SetActive(true);
                text.SetActive(true); 
            }
            else if (!tutorial.activeSelf) {
                tutorial.SetActive(true);
                playbutton.SetActive(false);
                text.SetActive(false); 
            }
        }
        if (Input.GetKeyDown(KeyCode.R) && tutorial.activeSelf == false) {
            if (credits.activeSelf)
            {
                credits.SetActive(false);
            }
            else if (!credits.activeSelf) {
                credits.SetActive(true); 
            }
        }
    }

   
}
