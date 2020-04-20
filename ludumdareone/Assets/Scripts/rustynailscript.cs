using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class rustynailscript : MonoBehaviour
{
    public GameObject nailpanel;
    public Text nailtext;
    public GameObject achivementunlocked;
    public GameObject nailachievement;
    public bool nailachievementunlock;
    public float timer = 0f;
    public bool runtimer;
    // Start is called before the first frame update
    void Start()
    {
        nailpanel.SetActive(false);
        achivementunlocked.SetActive(false);
        nailachievement.SetActive(false);
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
        if (playercontroller.achivement && nailachievementunlock)
        {
            nailachievement.SetActive(true);
        }
        Vector3 pos = Camera.main.WorldToScreenPoint(this.transform.position);
        pos.x = pos.x - 40;
        nailpanel.transform.position = pos;
    }

    private void OnMouseDown()
    {
        nailtext.text = "Nail";
        nailachievementunlock = true;
        achivementunlocked.SetActive(true);
        runtimer = true;
    }
    private void OnMouseOver()
    {
        nailpanel.SetActive(true);
    }

    private void OnMouseExit()
    {
        nailpanel.SetActive(false);
    }
}
