using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject achievements;
    public static bool achivement; 
    Rigidbody2D myrb;
    public bool caninteract;
    public GameObject robot;
    Animator animator;

    void Start()
    {
        achievements.SetActive(false);
        robotAI.achievementview = true;
        achivement = false;
        myrb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();         
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {
            if (achievements.activeSelf)
            {
                robotAI.achievementview = true;
                achivement = false; 
                achievements.SetActive(false);
            }
            else {
                achievements.SetActive(true);
                robotAI.achievementview = false;
                achivement = true; 
            }
        }
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
            //animator.SetBool("MovingLeft", true);
            animator.Play("left");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Vector3 position = this.transform.position;
            position.x += (float)0.20;
            this.transform.position = position;
            /*Animator sets bool to moving right to play animation*/
            // animator.SetBool("MovingRight", true);
            animator.Play("right");
        }
        else if (Input.GetKey(KeyCode.W))
        {
            Vector3 position = this.transform.position;
            position.y += (float)0.20;
            this.transform.position = position;
            /*Animator sets bool to moving up to play animation*/
            // animator.SetBool("MovingUp", true);
            animator.Play("backward");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Vector3 position = this.transform.position;
            position.y -= (float)0.20;
            this.transform.position = position;
            /*Animator sets bool to moving down to play animation*/
            // animator.SetBool("MovingDown", true);
            animator.Play("forward");
        }
        else {
            animator.Play("idle"); 
        }
    }
}
