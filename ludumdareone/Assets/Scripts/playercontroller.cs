using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D myrb;
    public bool caninteract;
    public GameObject robot;
    public Animator animator;
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
            position.x -= (float)0.20;
            this.transform.position = position;
            /*Animator sets bool to moving left to play animation*/
            animator.SetBool("MovingLeft", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Vector3 position = this.transform.position;
            position.x += (float)0.20;
            this.transform.position = position;
            /*Animator sets bool to moving right to play animation*/
            animator.SetBool("MovingRight", true);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            Vector3 position = this.transform.position;
            position.y += (float)0.20;
            this.transform.position = position;
            /*Animator sets bool to moving up to play animation*/
            animator.SetBool("MovingUp", true);
        }
        else if (Input.GetKey(KeyCode.S)) {
            Vector3 position = this.transform.position;
            position.y -= (float)0.20;
            this.transform.position = position;
            /*Animator sets bool to moving down to play animation*/
            animator.SetBool("MovingDown", true);
        }
    }
}
