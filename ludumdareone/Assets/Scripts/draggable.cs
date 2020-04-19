using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draggable : MonoBehaviour
{
    Vector2 initalposition;

    Vector2 mouseposition;

    float deltaX, deltaY;

    // Start is called before the first frame update
    void Start()
    {
        initalposition = this.transform.position;
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - this.transform.position.x;
        deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - this.transform.position.y;
    }

    private void OnMouseDrag()
    {
        mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = new Vector2(mouseposition.x - deltaX, mouseposition.y - deltaY);
        AstarPath.active.Scan();
    }

}
