using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public static InputMaster inputs;

    public static bool isPlayerHere;
    public static bool worldUIButtonPressed;
    public static bool isPaused;

    private PlayerMoveMent pm;
    private BasicGun bg;
    private PauseController pc;

    private void Awake()
    {
        inputs = new InputMaster();
        pm = FindObjectOfType<PlayerMoveMent>();
        bg = FindObjectOfType<BasicGun>();
        pc = FindObjectOfType<PauseController>();
    }
    
    private void Start()
    {
        //player inputs
        inputs.Player.Jump.performed += _ => Jump();

        inputs.Player.Shoot.performed += _ => ShootPressed();

        inputs.Player.UnShoot.performed += _ => ShootReleased();
        
        //ui inputs
        inputs.UIActivateWorld.WorldUI.performed += _ => LevelSelect();
        
        inputs.UIActivateWorld.ExitAllUi.performed += _ => PauseUI();

    }
    
    private void OnEnable()
    {
        inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }
    
    void Jump()
    {
        if (pm.controller.m_Grounded)
        {
            PlayerMoveMent.jump = true;
        }
        
    }
    
    private void LevelSelect()
    {
        if (isPlayerHere)
        {
            worldUIButtonPressed = !worldUIButtonPressed;
        }
    }
    
    private void ShootPressed()
    {
        bg.isFiring = true;
    }

    private void ShootReleased()
    {
        bg.isFiring = false;
        bg.anim.SetBool("isShooting", false);
    }

    private void PauseUI()
    {
        isPaused = !isPaused;
    }
}
