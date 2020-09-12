using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

using UnityEngine.InputSystem;

public class GunBase : MonoBehaviour
{
    [SerializeField] public GameObject bulletObject;
    [SerializeField] Transform firePoint;
    [SerializeField] int maxBullet;
    [SerializeField] public float shootTimerMax;

    [HideInInspector]
    public float shootTimer;
    [HideInInspector]
    public float currBullet;
    public bool isFiring;
    bool shoot;
    public Animator anim;
    private bool m_FacingRight = true;

    private Transform crossHair;
    
    public PlayerMoveMent pm;

    private Camera main;

    public virtual void Start()
    {
        crossHair = GameObject.FindGameObjectWithTag("CrossHair").transform;
        currBullet = maxBullet;
        shootTimer = shootTimerMax;
        anim = GetComponent<Animator>();
        
        main = Camera.main;
    }

    public virtual void Update()
    {
        CrossHairAim();
        
        if (Time.timeScale > 0)
        {
            if(isFiring && currBullet >= 0 && !shoot)
            {
                StartCoroutine(Shoot());
                anim.SetBool("isShooting", true);
                shoot = true;
            }

            else if (shoot)
            {
                shootTimer -= Time.deltaTime;
                if(shootTimer <= 0)
                {
                    shootTimer = shootTimerMax;
                    shoot = false;
                }
            }

            /*if(Input.GetButtonUp("Fire1"))
            {
                isFiring = false;
                anim.SetBool("isShooting", false);
            }*/
       
        }
    }

    private void CrossHairAim()
    {
        Vector2 mouseScreenPos = PlayerInputs.inputs.Player.MousePosition.ReadValue<Vector2>();
        Vector3 mouseWorldPos = main.ScreenToWorldPoint(mouseScreenPos);

        Vector3 targetDir = mouseWorldPos - transform.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;

       // crossHair.position = new Vector3(mouseWorldPos.x, mouseWorldPos.y, 0f);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    public virtual IEnumerator Shoot()
    {
        currBullet--;
        GameObject bulletTemp = Instantiate(bulletObject, firePoint.position, firePoint.rotation);
        yield return new WaitForSeconds(3f);
        Destroy(bulletTemp);
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}
