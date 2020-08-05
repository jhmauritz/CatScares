using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Pathfinding;

public class AIDrop : MonoBehaviour, IStateMachine
{
    public Transform[] arrayPoints;

    public enum States
    {
        IDLE,
        DROP,
        SWING
    };

    public States state = States.IDLE;
    public Animator anim;
    public Animator stretchAnim;
    public GameObject bullet;
    public Transform shootPoint;
    public float fireRate = 1f;
    public Transform dropPoint;
    public Transform startPoint;
    public GameObject stretcher;
    
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
    private bool isDropPoint;
    private bool isStartPoint;

    private Vector3 drop;
    private Vector3 start;
    private bool fromDrop;
    private bool isAnimDone;
    [SerializeField]
    public AnimationClip stretch;

    private void Start()
    {
        EnterState();
    }

    private void Update()
    {
        Flip();
        InState();
        ExitState();

    }

    private void Swing()
    {
        isAnimDone = false;
        fireRateInner -= Time.deltaTime;

        if (fireRateInner <= 0)
        {
            fireRateInner = fireRate;
            Instantiate(bullet, shootPoint.position, Quaternion.identity);
        }
    }

    private void Drop()
    {
        StartCoroutine(WaitForAnimation(stretch));
        
        float speed = 1f;
        float newScale = transform.position.y;

        if (!isDropPoint)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
            stretchAnim.SetBool("IsStretching", true);
            stretchAnim.SetBool("IsNotStretching", false);
            
            fromDrop = true;
        }
        else
        {
            return;
        }
    }

    private IEnumerator WaitForAnimation(AnimationClip clip)
    {
        yield return new WaitForSeconds(stretch.length);
        isAnimDone = true;
    }

    private void Watch()
    {
        float speed = 1f;
        
        if (!isStartPoint)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
            if (fromDrop)
            {
                stretchAnim.SetBool("IsNotStretching", true);
                stretchAnim.SetBool("IsStretching", false);
                fromDrop = false;
            }
        }
        else
        {
            return;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DropPoint"))
        {
            isDropPoint = true;
        }
        if (other.gameObject.CompareTag("StartPoint"))
        {
            isStartPoint = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DropPoint"))
        {
            isDropPoint = false;
        }
        if (other.gameObject.CompareTag("StartPoint"))
        {
            isStartPoint = false;
        }
    }

    public void EnterState()
    {
        seeker = GetComponent<Seeker>();
        agent = GetComponent<IAstarAI>();
        player = FindObjectOfType<PlayerHealth>().transform;
        aiPath = GetComponent<AIPath>();
        
        start = startPoint.position;
        drop = dropPoint.position;

        fireRateInner = fireRate;
    }

    public void InState()
    {
        switch (state)
        {
            case States.IDLE:
                Watch();
                break;
            case States.DROP:
                Drop();
                break;
            case States.SWING:
                Swing();
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
                        state = States.DROP;
                    }

                    break;
                case States.DROP:
                    if (followDist <= attackRadius && isAnimDone)
                    {
                        state = States.SWING;
                    }

                    break;
                case States.SWING:
                    if (followDist > spotRadius)
                    {
                        state = States.IDLE;
                    }

                    break;
            }
        }
    }
}
