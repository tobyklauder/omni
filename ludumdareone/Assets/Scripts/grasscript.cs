using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class grasscript : MonoBehaviour
{
    public GameObject achivementunlocked;
    public GameObject grassachievement;
    public bool grassachivementunlocked;
    public float timer = 0f; 
    public bool runtimer; 
    // Start is called before the first frame update
    void Start()
    {
        achivementunlocked.SetActive(false);
        grassachievement.SetActive(false); 
    }

    private void OnMouseDown()
    {
        grassachivementunlocked = true;
        achivementunlocked.SetActive(true);
        runtimer = true; 
    }

    // Update is called once per frame
    void Update()
    {
        if (runtimer) {
            timer += Time.deltaTime; 
        }
        if (timer > 5) {
            runtimer = false;
            timer = 0;
            achivementunlocked.SetActive(false); 
        }
        if (playercontroller.achivement && grassachivementunlocked) {
            grassachievement.SetActive(true); 
        }

    }

   
}
