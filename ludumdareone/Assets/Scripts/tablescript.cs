using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tablescript : MonoBehaviour
{
    public GameObject tablepanel;
    // Start is called before the first frame update
    void Start()
    {
        tablepanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(this.transform.position);
        pos.x = pos.x - 48;
        tablepanel.transform.position = pos;
    }

    private void OnMouseOver()
    {
        tablepanel.SetActive(true);
    }

    private void OnMouseExit()
    {
        tablepanel.SetActive(false);
    }
}
