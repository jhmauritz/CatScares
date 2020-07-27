using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public virtual void Start()
    {
        currBullet = maxBullet;
        shootTimer = shootTimerMax;
        anim = GetComponent<Animator>();
    }

    public virtual void Update()
    {
        if(Time.timeScale > 0)
        {
            if(Input.GetButton("Fire1") && currBullet >= 0 && !shoot)
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

            if(Input.GetButtonUp("Fire1"))
            {
                isFiring = false;
                anim.SetBool("isShooting", false);
            }
        }
    }

    public virtual IEnumerator Shoot()
    {
        currBullet--;
        GameObject bulletTemp = Instantiate(bulletObject, firePoint.position, firePoint.rotation);
        yield return new WaitForSeconds(3f);
        Destroy(bulletTemp);
    }
}
