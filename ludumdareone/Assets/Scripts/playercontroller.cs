using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D myrb; 
    void Start()
    {
        myrb = GetComponent<Rigidbody2D>(); 
    }
    private void Update()
    {
        myrb.velocity = Vector2.zero; 
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 position = this.transform.position;
            position.x -= (float)0.30;
            this.transform.position = position;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Vector3 position = this.transform.position;
            position.x += (float)0.30;
            this.transform.position = position;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            Vector3 position = this.transform.position;
            position.y += (float)0.30;
            this.transform.position = position;
        }
        else if (Input.GetKey(KeyCode.S)) {
            Vector3 position = this.transform.position;
            position.y -= (float)0.30;
            this.transform.position = position; 
        }
    }
}
