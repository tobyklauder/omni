using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding; 
public class robotAI : MonoBehaviour
{
    public float timer;
    public float idletimer; 
    //objects that can be targeted and can hurt the robot 
    public static GameObject fridge;
    public static GameObject stairs;
    public static GameObject circuitbreaker;
    public static GameObject pool;
    public static GameObject bathtub;
    public static GameObject table;
    public static GameObject stump;
    //end list of objects that can be targeted and hurt the robot 
    public GameObject[] allpossible = new GameObject[7];
    public Collider2D[] colliders;
    public GameObject[] allpassivepoints = new GameObject[4]; 
    //(above) list of all targeted objects 
    public int idletime;
    public int randhurttarget;
    public int randpassivetarget; 
    //set these below to true in update if robot is in range of target 
    public bool fridgedetected; //kitchen
    public bool stairsdetected; //living room
    public bool circuitbreakerdetected; //living room
    public bool pooldetected; //backyard 
    public bool bathtubdetected; //bathroom
    public bool tabledetected; //kitchen
    public bool stumpdetected; //backyard 
    public bool anydetected;
    public static bool anydetecteduni; 
    public static bool pursuepassive; 
    Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    Path path;
    int currentWaypoint = 0;
    public bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb; 

    // Start is called before the first frame update
    void Start()
    { 
        idletime = Random.Range(0, 20);
        randhurttarget = Random.Range(0, 2);
        randpassivetarget = Random.Range(0, 4); 
        Debug.Log("Targeting " + randhurttarget.ToString()); 
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
        if (path == null) {
            return; 
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else {
            reachedEndOfPath = false; 
        }

        Vector2 direction = ((Vector2) path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force); 

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance) {
            currentWaypoint++; 
        }
    }

    private void Update()
    {
        anydetecteduni = anydetected; 
        colliders = Physics2D.OverlapCircleAll(this.transform.position, 5f);
        for (int i = 0; i < colliders.Length; i++) {
            if (colliders[i].gameObject.tag == "fridge") {
                fridgedetected = true; 
            }
            else if (colliders[i].gameObject.tag == "stairs") {
                stairsdetected = true; 
            }
        }
        if (stairsdetected || fridgedetected) {
            anydetected = true; 
        }
        if (anydetected) {
            timer += Time.deltaTime; 
        }
        if (timer >= 30) {
            Debug.Log("You loose!"); 
        }
        if (pursuepassive) {
            timer = 0; 
            this.transform.position = allpassivepoints[randpassivetarget].transform.position;
            target = null; 
            idletimer += Time.deltaTime;
            if (idletimer > idletime) {
                randhurttarget = Random.Range(0, 2);
                target = allpossible[randhurttarget].transform;
                pursuepassive = false;
                idletimer = 0; 
            }
            }
        }
        
    }

