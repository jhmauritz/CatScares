using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AIPatrol : MonoBehaviour
{
    public Transform[] arrayPoints;

    public enum States
    {
        PATROL,
        FOLLOW,
        ATTACK
    };

    public States state = States.PATROL;
    public Animator anim;
    
    Transform[] patrolPoints;
    public float delay = 0;
    public float spotRadius;
    public float attackRadius;
    
    IAstarAI agent;
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
    }

    private void Update()
    {
        PlayerCheck();
        
        switch (state)
        {
            case States.PATROL:
                Patrol();
                break;
            case States.FOLLOW:
                FollowPLayer();
                break;
            case States.ATTACK:
                Attack();
                break;
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
            state = States.PATROL;
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
