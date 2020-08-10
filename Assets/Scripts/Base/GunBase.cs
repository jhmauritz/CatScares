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
    bool isFiring;
    bool shoot;
    Animator anim;
    private bool m_FacingRight = true;
    
    public PlayerMoveMent pm;

    public virtual void Start()
    {
        
        currBullet = maxBullet;
        shootTimer = shootTimerMax;
        anim = GetComponent<Animator>();
    }

    public virtual void Update()
    {

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

    public void ShootPressed()
    {
        isFiring = true;
    }

    public void ShootReleased()
    {
        isFiring = false;
        anim.SetBool("isShooting", false);
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
