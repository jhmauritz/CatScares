using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveMent : MonoBehaviour
{
    public static int levelsCompleted;
    
    public float runSpeed;

    public GameObject pauseMenu;
    public GameObject levelMenu;

    [HideInInspector]
    public CharacterController controller;

    float horizMove = 0;
    public static bool jump;

    //newInput system
    private Vector2 wasdInput;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    

    private void Update()
    {
        PlayerInput();
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
