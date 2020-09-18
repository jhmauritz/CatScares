using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        CrossHairMoveMent();
    }
    

    private void CrossHairMoveMent()
    {
        //follow cursor
        Vector3 mousePos = PlayerInputs.inputs.Player.MousePosition.ReadValue<Vector2>();
        mousePos.z = transform.position.z - cam.transform.position.z;

        Vector3 worldPos = cam.ScreenToWorldPoint(mousePos);

        transform.position = worldPos;
    }
}
