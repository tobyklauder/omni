using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circuitbrakerscript : MonoBehaviour
{
    public GameObject circuitpanel;
    // Start is called before the first frame update
    void Start()
    {
        circuitpanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(this.transform.position);
        pos.x = pos.x - 48;
        circuitpanel.transform.position = pos;
    }

    private void OnMouseOver()
    {
        circuitpanel.SetActive(true);
    }

    private void OnMouseExit()
    {
        circuitpanel.SetActive(false);
    }
}
