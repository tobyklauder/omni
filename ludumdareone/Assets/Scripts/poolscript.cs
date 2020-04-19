using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poolscript : MonoBehaviour
{
    public GameObject poolpanel;
    // Start is called before the first frame update
    void Start()
    {
        poolpanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(this.transform.position);
        pos.x = pos.x - 48;
        poolpanel.transform.position = pos;
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
