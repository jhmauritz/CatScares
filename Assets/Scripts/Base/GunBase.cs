using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

using UnityEngine.InputSystem;

public class GunBase : MonoBehaviour
{
    [SerializeField] public GameObject bulletObject;
    [SerializeField] public Transform firePoint;
    [SerializeField] private int maxBullet = 0;
    [SerializeField] public float shootTimerMax;

    [HideInInspector]
    public float shootTimer;
    [HideInInspector]
    public float currBullet;
    public bool isFiring;
    bool shoot;
    public Animator anim;
    [HideInInspector]
    public bool m_FacingRight = true;

    private Transform crossHair;
    
    public PlayerMoveMent pm;

    private Camera main;

    public virtual void Start()
    {
        pm = FindObjectOfType<PlayerMoveMent>();
        crossHair = GameObject.FindGameObjectWithTag("CrossHair").transform;
        currBullet = maxBullet;
        shootTimer = shootTimerMax;
        anim = GetComponent<Animator>();
        
        main = Camera.main;
    }

    public virtual void Update()
    {
        if(!PauseController.isPausedMenu)
        {
            CrossHairAim();
        }
        else 
        {
            return;
        }
        
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
        }
        
        //check which way gun is facing
        
        // TRANSFER MOUSE POSITION FROM OLD INPUT SYSTEM TO NEW INPUT SYETM
        
        var viewPortCoord = main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        if (viewPortCoord.x >= 0)
        {
            transform.localScale = new Vector3(1,1,1);
        }
        else if (viewPortCoord.x < 0)
        {
            transform.localScale = new Vector3(1,-1,-1);
        }
    }

    private void CrossHairAim()
    {
        Vector3 target = crossHair.position;
        target.z = 0f;

        Vector3 objectPos = transform.position;
        target.x = target.x - objectPos.x;
        target.y = target.y - objectPos.y;

        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    public virtual IEnumerator Shoot()
    {
        currBullet--;
        GameObject bulletTemp = Instantiate(bulletObject, firePoint.position, firePoint.rotation);
        yield return new WaitForSeconds(3f);
        Destroy(bulletTemp);
    }
}
