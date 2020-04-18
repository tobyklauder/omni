using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class ovenscript : MonoBehaviour
{
    public GameObject fridgetext; 
    // Start is called before the first frame update
    void Start()
    {
        fridgetext.SetActive(false); 
        
    }

    private void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(this.transform.position);
        pos.x = pos.x - 33;
        pos.y = pos.y - 20; 
        fridgetext.transform.position = pos; 
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
