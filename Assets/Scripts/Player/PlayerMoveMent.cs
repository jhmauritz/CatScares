using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMoveMent : MonoBehaviour
{
    public float runSpeed;

    CharacterController controller;

    float horizMove = 0;
    bool jump;

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
        controller.Move(horizMove * Time.fixedDeltaTime, false,jump);
        jump = false;
    }

    void PlayerInput()
    {
       horizMove =  Input.GetAxisRaw("Horizontal") * runSpeed;

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }
}
