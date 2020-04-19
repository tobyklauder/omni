using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bathtubscript : MonoBehaviour
{

    public GameObject bathtubpanel;
    // Start is called before the first frame update
    void Start()
    {
        bathtubpanel.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(this.transform.position);
        pos.x = pos.x - 50; 
        bathtubpanel.transform.position = pos; 
    }

    private void OnMouseOver()
    {
        bathtubpanel.SetActive(true); 
    }

    private void OnMouseExit()
    {
        bathtubpanel.SetActive(false); 
    }
}
