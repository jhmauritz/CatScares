﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AIShoot : MonoBehaviour, IStateMachine
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
    public Transform shootPoint;
    public float fireRate = 1f;
    
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

    private bool shoot;
    private float fireRateInner;

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
        InState();
        ExitState();

        if (shoot)
        {
            fireRateInner -= Time.deltaTime;
            if (fireRateInner <= 0)
            {
                shoot = false;
                fireRateInner = fireRate;
            }
        }
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

    void FollowPLayer()
    {
        if(player != null)
            agent.destination = player.position;
    }

    void Attack()
    {
        if (Time.timeScale > 0)
        {
            if(!shoot)
            {
                StartCoroutine(Shoot());
                shoot = true;
            }
        }
    }

    IEnumerator Shoot()
    {
        GameObject bullTemp = Instantiate(bullet, shootPoint.position, Quaternion.identity);
        yield return new WaitForSeconds(3f);
        Destroy(bullTemp);
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

    public void EnterState()
    {
        seeker = GetComponent<Seeker>();
        agent = GetComponent<IAstarAI>();
        player = FindObjectOfType<PlayerHealth>().transform;
        aiPath = GetComponent<AIPath>();

        fireRateInner = fireRate;
    }

    public void InState()
    {
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
    }

    public void ExitState()
    {
        if (player != null)
        {
            float followDist = Vector2.Distance(transform.position, player.position);

            switch (state)
            {
                case States.IDLE:
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
                        state = States.IDLE;
                    }

                    break;
            }
        }
    }
}
