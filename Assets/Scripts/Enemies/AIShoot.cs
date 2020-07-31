using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AIShoot : MonoBehaviour
{
    public Transform[] arrayPoints;

    public enum States
    {
        IDLE,
        FOLLOW,
        ATTACK
    };

    public States state = States.IDLE;
    public Animator anim;
    public GameObject bullet;
    
    Transform[] patrolPoints;
    public float delay = 0;
    public float spotRadius;
    public float attackRadius;
    
    IAstarAI agent;
    private AIPath aiPath;
    float switchTime = float.PositiveInfinity;
    private Seeker seeker;
    private Transform player;
    private int index = 0;
    

    private void Awake()
    {
        patrolPoints = arrayPoints;
    }

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        agent = GetComponent<IAstarAI>();
        player = GameObject.FindObjectOfType<PlayerHealth>().transform;
        aiPath = GetComponent<AIPath>();
    }

    private void Update()
    {
        Flip();
        PlayerCheck();
        
        switch (state)
        {
            case States.IDLE:
                Patrol();
                break;
            case States.FOLLOW:
                FollowPLayer();
                break;
            case States.ATTACK:
                Attack();
                break;
        }

        Instantiate(bullet);
    }

    void Flip()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    void PlayerCheck()
    {
        float followDist = Vector2.Distance(transform.position, player.position);

        if (followDist <= spotRadius)
        {
            state = States.FOLLOW;
        }
        
        if (followDist > spotRadius)
        {
            state = States.IDLE;
        }
        
        if (followDist <= attackRadius)
        {
            state = States.ATTACK;
        }
    }

    void FollowPLayer()
    {
        if(player != null)
            agent.destination = player.position;
    }

    void Attack()
    {
        Debug.Log("Attack");
    }

    void Shoot()
    {
        
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0)
            return;

        bool search = false;
        
        if (agent.reachedEndOfPath && !agent.pathPending && float.IsPositiveInfinity(switchTime)) 
        {
            switchTime = Time.time + delay;
        }
        
        if (Time.time >= switchTime) 
        {
            index = index + 1;
            search = true;
            switchTime = float.PositiveInfinity;
        }

        index = index % patrolPoints.Length;
        agent.destination = patrolPoints[index].position;

        if (search) agent.SearchPath();
    }
}
