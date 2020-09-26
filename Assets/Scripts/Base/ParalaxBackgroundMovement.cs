using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxBackgroundMovement : MonoBehaviour
{
    private Transform mainCamera;
    private Camera camera;

    [SerializeField] private float bagroundMoveSpeed;
    private float dirX;
    [SerializeField] private float offsetByX = 13f;

    void Awake()
    {
        camera = Camera.main;
        mainCamera = camera.transform;
    }

    void Update()
    {
        if(PlayerMoveMent.isMoving)
        {
            MovingBackground();
        }
        else
        {
            return;
        }
    }

    private void MovingBackground()
    {
        float horizMove = PlayerInputs.inputs.Player.Movement.ReadValue<float>();
        dirX = horizMove * bagroundMoveSpeed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x + dirX, transform.position.y);

        if(transform.position.x - mainCamera.position.x < -offsetByX)
            {
                transform.position = new Vector2(mainCamera.position.x + offsetByX, transform.position.y);
            }
            else if(transform.position.x - mainCamera.position.x > offsetByX)
            {
                transform.position = new Vector2(mainCamera.position.x - offsetByX, transform.position.y);
            }
    }

}
