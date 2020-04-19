using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poolscript : MonoBehaviour
{
    public GameObject poolpanel;
    public GameObject achivementunlocked;
    public GameObject poolachivement;
    public bool poolachivementunlock;
    public float timer = 0f;
    public bool runtimer;
    // Start is called before the first frame update
    void Start()
    {
        poolpanel.SetActive(false);
        achivementunlocked.SetActive(false);
        poolachivement.SetActive(false); 
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
        if (playercontroller.achivement && poolachivementunlock) {
            poolachivement.SetActive(true); 
        }
        Vector3 pos = Camera.main.WorldToScreenPoint(this.transform.position);
        pos.x = pos.x - 48;
        poolpanel.transform.position = pos;
    }

    private void OnMouseDown()
    {
        poolachivementunlock = true;
        achivementunlocked.SetActive(true);
        runtimer = true; 
    }
    private void OnMouseOver()
    {
        poolpanel.SetActive(true);
    }

    private void OnMouseExit()
    {
        poolpanel.SetActive(false);
    }
}
