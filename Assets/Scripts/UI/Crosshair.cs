using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    private Camera cam;
    public Transform gun;
    public float followSharpness;

    private Vector3 followOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        followOffset = transform.position - gun.position;
    }

    // Update is called once per frame
    void Update()
    {
        CrossHairMoveMent();
    }
    

    private void CrossHairMoveMent()
    {
        //constant x value
        Vector3 targetPos = transform.position + followOffset;

        //follow cursor
        Vector3 mousePos = PlayerInputs.inputs.Player.MousePosition.ReadValue<Vector2>();
        mousePos.z = transform.position.z - cam.transform.position.z;
        
        Vector3 clampedMousPos = new Vector3(transform.position.x, 
            Mathf.Clamp(mousePos.y, 98f, 200f), 
            mousePos.z);
            
        transform.position += (targetPos - transform.position) * followSharpness;
        transform.position = cam.ScreenToWorldPoint(clampedMousPos);
    }
}
