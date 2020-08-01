using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AIPatrol : MonoBehaviour, IStateMachine
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

    IAstarAI agent;
    private AIPath aiPath;
    float switchTime = float.PositiveInfinity;
    private Seeker seeker;
    private Transform player;
    private int index = 0;

    public float spotRadius;
    public float attackRadius;
    

    private void Awake()
    {
        patrolPoints = arrayPoints;
    }

    private void Start()
    {
        EnterState();
    }

    private void Update()
    {
        
        Flip();
        ExitState();
        InState();
    }
    
    void Flip()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    public void EnterState()
    {
        seeker = GetComponent<Seeker>();
        agent = GetComponent<IAstarAI>();
        player = GameObject.FindObjectOfType<PlayerHealth>().transform;
        aiPath = GetComponent<AIPath>();
    }

    public void InState()
    {
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

    public void ExitState()
    {
        if (player != null)
        {
            float followDist = Vector2.Distance(transform.position, player.position);

            switch (state)
            {
                case States.PATROL:
                    if (followDist <= spotRadius)
                    {
                        state = States.FOLLOW;
                    }

                    break;
                case States.FOLLOW:
                    if (followDist <= attackRadius)
                    {
                        state = States.ATTACK;
                    }

                    break;
                case States.ATTACK:
                    if (followDist > spotRadius)
                    {
                        state = States.PATROL;
                    }

                    break;
            }
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
