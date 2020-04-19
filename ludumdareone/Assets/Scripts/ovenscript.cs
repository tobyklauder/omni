using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class ovenscript : MonoBehaviour
{
    public GameObject fridgetext;
    public GameObject fridgeachivement;
    public GameObject achivementunlocked;
    public bool fridgeachivementunlock;
    public float timer = 0f;
    public bool runtimer; 
    // Start is called before the first frame update
    void Start()
    {
        fridgetext.SetActive(false);
        fridgeachivement.SetActive(false);
        achivementunlocked.SetActive(false); 
    }

    private void Update()
    {
        if (runtimer) {
            timer += Time.deltaTime; 
        }
        if (timer > 5) {
            runtimer = false; 
            timer = 0;
            achivementunlocked.SetActive(false); 
        }
        if (playercontroller.achivement && fridgeachivementunlock) {
            fridgeachivement.SetActive(true); 
        }
        Vector3 pos = Camera.main.WorldToScreenPoint(this.transform.position);
        pos.x = pos.x - 45;
        pos.y = pos.y - 20; 
        fridgetext.transform.position = pos; 
    }
    private void OnMouseDown()
    {
        fridgeachivementunlock = true;
        achivementunlocked.SetActive(true); 
        runtimer = true; 
    }
    private void OnMouseOver()
    {
        fridgetext.SetActive(true); 
    }

    private void OnMouseExit()
    {
        fridgetext.SetActive(false); 
    }
}
