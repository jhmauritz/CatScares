using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class IdleBehaviour : StateMachineBehaviour
{
    Transform playerPos;
    public float spotRadius;

    public Transform pos1;
    public Transform pos2;
    public float speed;
    Vector2 posVect1;
    Vector2 posVect2;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        posVect1 = pos1.position;
        posVect2 = pos2.position;
    }


    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float dist = Vector2.Distance(animator.transform.position, playerPos.position);

        if (dist < spotRadius)
        {
            animator.SetBool("isFollowing", true);
        }
        else
        {
            animator.SetBool("isFollowing", false);
            animator.gameObject.transform.position = Vector2.Lerp(posVect1, posVect2, Mathf.PingPong(Time.fixedTime * speed, 1f));
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
