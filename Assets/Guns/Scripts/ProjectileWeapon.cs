using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ProjectileWeapon : Weapon
{

    [SerializeField] protected GameObject projectile;
    public float projectileForce;
    private bool canShoot = true;
    protected override void StartShooting(ActivateEventArgs args)
    {
        base.StartShooting(args);
        Shoot();
    }

    protected override void StopShooting(DeactivateEventArgs args)
    {
        base.StopShooting(args);
    }

    protected override void Shoot()
    {
        GameObject bullet = Instantiate(projectile, bulletSpawn.position, Quaternion.identity);
    }
    
}
