using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stairsscript : MonoBehaviour
{

    public GameObject stairpanel; 
    // Start is called before the first frame update
    void Start()
    {
        stairpanel.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(this.transform.position);
        pos.x = pos.x - 35; 
        stairpanel.transform.position = pos; 
    }

    private void OnMouseOver()
    {
        stairpanel.SetActive(true); 
    }

    private void OnMouseExit()
    {
        stairpanel.SetActive(false); 
    }
}
