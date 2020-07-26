using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    [SerializeField] public GameObject bulletObject;
    [SerializeField] Transform firePoint;
    [SerializeField] int maxBullet;
    
    [HideInInspector]
    public float currBullet;
    bool isFiring;
    Animator anim;

    public virtual void Start()
    {
        currBullet = maxBullet;
        anim = GetComponent<Animator>();
    }

    public virtual void Update()
    {
        if(Time.timeScale > 0)
        {
            if(Input.GetButton("Fire1") && currBullet >= 0)
            {
                StartCoroutine(Shoot());
                anim.SetBool("isShooting", true);
            }

            else if(Input.GetButtonUp("Fire1"))
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
