using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveMent : MonoBehaviour
{
    public static int checkpointIndexCompleted;
    public static int levelsCompleted;
    public static int isFirstPlayerHubEncounter = 0;
    
    public float runSpeed;

    public static bool isMoving;

    public GameObject pauseMenu;
    public GameObject levelMenu;

    [HideInInspector]
    public CharacterController controller;

    float horizMove = 0;
    public static bool jump;

    //newInput system
    private Vector2 wasdInput;
    private Rigidbody2D rb;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody2D>();
    }
    

    private void Update()
    {
        PlayerInput();

        if(rb.velocity.magnitude > 0 || rb.velocity.magnitude < 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizMove * Time.fixedDeltaTime * runSpeed, false,jump);
        jump = false;
    }

    void PlayerInput()
    {
        //read movement value
        horizMove = PlayerInputs.inputs.Player.Movement.ReadValue<float>();
    }
}
