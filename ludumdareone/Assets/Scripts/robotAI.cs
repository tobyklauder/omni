﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 
public class robotAI : MonoBehaviour
{
    public int targetrange = 5;
    public float wintimer = 120f; 
    public float timer;
    public float attempttimer; 
    public GameObject siren; 
    //objects that can be targeted and can hurt the robot 
    public static GameObject fridge;
    public static GameObject stairs;
    public static GameObject circuitbraker;
    public static GameObject pool;
    public static GameObject bathtub;
    public static GameObject table;
    public static GameObject stump;
    //end list of objects that can be targeted and hurt the robot 
    public GameObject[] allpossible; 
    public Collider2D[] colliders;
    public GameObject[] allpassivepoints = new GameObject[4]; 
    //(above) list of all targeted objects 
    public int idletime;
    public int randhurttarget;
    public static int randpassivetarget; 
    //set these below to true in update if robot is in range of target 
    public bool fridgedetected; //kitchen
    public bool stairsdetected; //living room
    public bool circuitbrakerdetected; //living room
    public bool pooldetected; //backyard 
    public bool bathtubdetected; //bathroom
    public bool tabledetected; //kitchen
    public bool stumpdetected; //backyard 
    public bool anydetected;
    public static bool anydetecteduni; 
    public static bool pursuepassive;
    public static bool achievementview;
    public static bool sirenup;
    public bool switchclipbool; 
    Transform target;
    float speed = 400f;
    public float nextWaypointDistance = 3f;

    Path path;
    int currentWaypoint = 0;
    public bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        fridge = GameObject.FindGameObjectWithTag("fridge");
        stairs = GameObject.FindGameObjectWithTag("stairs");
        circuitbraker = GameObject.FindGameObjectWithTag("circuitbraker");
        pool = GameObject.FindGameObjectWithTag("pool");
        bathtub = GameObject.FindGameObjectWithTag("bathtub");
        table = GameObject.FindGameObjectWithTag("table");
        stump = GameObject.FindGameObjectWithTag("stump");
        sirenup = false; 
        siren.SetActive(false); //warning siren image - not visible by default 
        randhurttarget = Random.Range(0, 7); //get target 
        randpassivetarget = Random.Range(0, 4);
        //Debug.Log("Targeting " + randhurttarget.ToString()); 
        this.transform.position = allpassivepoints[randpassivetarget].transform.position; 
        //pathfinding stuff 
        target = allpossible[randhurttarget].transform; 
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, .5f); 
    }

    void UpdatePath() {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p) {
        if (!p.error) {
            path = p;
            currentWaypoint = 0; 
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (achievementview)
        {

            if (path == null)
            {
                return;
            }
            if (currentWaypoint >= path.vectorPath.Count)
            {
                reachedEndOfPath = true;
                return;
            }
            else
            {
                reachedEndOfPath = false;
            }

            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
            Vector2 force = direction * speed * Time.deltaTime;

            rb.AddForce(force);

            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

            if (distance < nextWaypointDistance)
            {
                currentWaypoint++;
            }
        }
        animator.Play("LudumRobot");
    }

    void Update()
    {
        wintimer -= Time.deltaTime;
        anydetecteduni = anydetected;
      
        /*colliders = Physics2D.OverlapCircleAll(this.transform.position, 1f);
        for (int i = 0; i < colliders.Length; i++) {
            if (colliders[i].gameObject.tag == "fridge")
            {
                fridgedetected = true;
            }
            else if (colliders[i].gameObject.tag == "stairs")
            {
                stairsdetected = true;
            }
            else if (colliders[i].gameObject.tag == "bathtub")
            {
                bathtubdetected = true;
            }
            else if (colliders[i].gameObject.tag == "circuitbraker")
            {
                circuitbrakerdetected = true;
            }
            else if (colliders[i].gameObject.tag == "table")
            {
                tabledetected = true;
            }
            else if (colliders[i].gameObject.tag == "pool")
            {
                pooldetected = true;
            }
            else if (colliders[i].gameObject.tag == "stump") 
            {
                stumpdetected = true; 
            }
        } */

        if (Vector3.Distance(this.transform.position, fridge.transform.position) < targetrange)
        {
            fridgedetected = true;
        }
        else {
            fridgedetected = false;
        }
        if (Vector3.Distance(this.transform.position, stairs.transform.position) < targetrange)
        {
            stairsdetected = true;
        }
        else {
            stairsdetected = false;
        }
        if (Vector3.Distance(this.transform.position, bathtub.transform.position) < targetrange)
        {
            bathtubdetected = true;
        }
        else {
            bathtubdetected = false; 
        }
        if (Vector3.Distance(this.transform.position, circuitbraker.transform.position) < targetrange)
        {
            circuitbrakerdetected = true;
        }
        else {
            circuitbrakerdetected = false; 
        }
        if (Vector3.Distance(this.transform.position, table.transform.position) < targetrange)
        {
            tabledetected = true;
        }
        else {
            tabledetected = false; 
        }
        if (Vector3.Distance(this.transform.position, pool.transform.position) < 7)
        {
            pooldetected = true;
        }
        else {
            pooldetected = false; 
        }
        if (Vector3.Distance(this.transform.position, stump.transform.position) < targetrange)
        {
            stumpdetected = true;
        }
        else {
            stumpdetected = false; 
        }
        if (stairsdetected || fridgedetected || bathtubdetected || circuitbrakerdetected || tabledetected || pooldetected || stumpdetected)
        {
            anydetected = true;
            siren.SetActive(true);
            sirenup = true;
            if (!switchclipbool) {
                musicmanager.switchclip("RobotCaught");
                switchclipbool = true; 
            }
        }
        else {
            anydetected = false; 
        }
        if (!anydetected)
        {
            attempttimer += Time.deltaTime;
            timer = 0;
            if (siren.activeSelf) {
                siren.SetActive(false);
                sirenup = false;
                if (switchclipbool) {
                    musicmanager.switchclip("RobotSearching");
                    switchclipbool = false; 
                }
 
            }
        }
        if (anydetected) {
            timer += Time.deltaTime;
            attempttimer = 0; 
        }
        if (timer >= 15) {
            SceneManager.LoadScene(2); 
        }
        if (attempttimer >= 20) {
            randhurttarget = Random.Range(0, 7);
            target = allpossible[randhurttarget].transform;
            attempttimer = 0; 
        }
        if (wintimer < 0) {
            SceneManager.LoadScene(3); 
        }
       // if (pursuepassive) {
         //   siren.SetActive(false); 
           // timer = 0; 
           // this.transform.position = allpassivepoints[randpassivetarget].transform.position;
           // target = null; 
          //  idletimer += Time.deltaTime;
          //  if (idletimer > idletime) {
           //     randhurttarget = Random.Range(0, 7);
            //    target = allpossible[randhurttarget].transform;
             //   pursuepassive = false;
             //   anydetected = false;
              //  bathtubdetected = false;
              //  stairsdetected = false;
              //  fridgedetected = false;
               // tabledetected = false;
               // pooldetected = false; 
               // circuitbrakerdetected = false; 
               // idletimer = 0; 
           // }
            //}
        }
        
    }

