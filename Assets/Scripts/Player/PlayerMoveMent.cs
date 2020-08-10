using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveMent : MonoBehaviour
{
    public float runSpeed;

    public GameObject pauseMenu;
    public GameObject levelMenu;

    CharacterController controller;
    public InputMaster controls;
    float horizMove = 0;
    bool jump;
    
    //static variables
    public static bool isPlayerHere;
    
    //newInput system
    private Vector2 wasdInput;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        
        //initializing input system
        controls = new InputMaster();
    }

    private void Start()
    {
        controls.Player.Jump.performed += _ => Jump();

        controls.UIActivateWorld.WorldUI.performed += _ => LevelSelect();

    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
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

    void Jump()
    {
        if (controller.m_Grounded)
        {
            jump = true;
        }
        
    }

    void PlayerInput()
    {
        //read movement value
        horizMove = controls.Player.Movement.ReadValue<float>();
    }

    public void LevelSelect()
    {
        if (isPlayerHere)
        {
            levelMenu.SetActive(true);
        }
    }
}
