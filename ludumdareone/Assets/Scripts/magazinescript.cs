using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class magazinescript : MonoBehaviour
{
    public GameObject magazinepanel;
    public Text magazinetext; 
    public GameObject achivementunlocked;
    public GameObject magazineachievement;
    public bool magazineachievementunlock;
    public float timer = 0f;
    public bool runtimer;
    // Start is called before the first frame update
    void Start()
    {
        magazinepanel.SetActive(false);
        achivementunlocked.SetActive(false);
        magazineachievement.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (runtimer)
        {
            timer += Time.deltaTime;
        }
        if (timer > 5)
        {
            runtimer = false;
            timer = 0;
            achivementunlocked.SetActive(false);
        }
        if (playercontroller.achivement && magazineachievementunlock)
        {
            magazineachievement.SetActive(true);
        }
        Vector3 pos = Camera.main.WorldToScreenPoint(this.transform.position);
        pos.x = pos.x - 40;
        magazinepanel.transform.position = pos;
    }

    private void OnMouseDown()
    {
        magazinetext.text = "Magazine"; 
        magazineachievementunlock = true;
        achivementunlocked.SetActive(true);
        runtimer = true;
    }
    private void OnMouseOver()
    {
        magazinepanel.SetActive(true);
    }

    private void OnMouseExit()
    {
        magazinepanel.SetActive(false);
    }
}
