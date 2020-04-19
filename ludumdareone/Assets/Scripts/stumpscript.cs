using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stumpscript : MonoBehaviour
{
    public GameObject stumppanel;
    // Start is called before the first frame update
    void Start()
    {
        stumppanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(this.transform.position);
        pos.x = pos.x - 48;
        stumppanel.transform.position = pos;
    }

    private void OnMouseOver()
    {
        stumppanel.SetActive(true);
    }

    private void OnMouseExit()
    {
        stumppanel.SetActive(false);
    }
}
