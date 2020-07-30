using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AIPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public Path path;
    public float speed = 3;
    public float nextWaypointDistance = 3;
    public bool reachedEndOfPath;
    
    private Seeker seeker;
    private Transform player;
    private int currWaypoint = 0;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        player = GameObject.FindObjectOfType<PlayerHealth>().transform;
        
        //go to first part of the path
        seeker.StartPath(transform.position, patrolPoints[1].position, OnPathComplete);
    }

    public void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            //Reset Waypoints
            currWaypoint = 0;
        }
    }

    private void Update()
    {
        if (path == null)
            return;

        reachedEndOfPath = false;
        float disttowaypoint;
    }
}
