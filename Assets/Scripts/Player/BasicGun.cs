using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : GunBase
{
    public override void Start()
    {
        base.Start();
        pm = GetComponentInParent<PlayerMoveMent>();

        pm.controls.Player.Shoot.performed += _ => ShootPressed();

        pm.controls.Player.UnShoot.performed += _ => ShootReleased();
    }

    public override void Update()
    {
        base.Update();
    }
}
