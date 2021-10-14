using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Stats")]
    [SerializeField] public float shootingFrequency;
    [SerializeField] public float bulletLifeSpan;
    [SerializeField] public float recoilForce;
    [SerializeField] public float damage;

    [Header("Components To Attach")]
    [SerializeField] protected Transform bulletSpawn;
    private Rigidbody _rigidbody;
    private XRGrabInteractable weaponInteractable;

    protected void Awake()
    {
        weaponInteractable = GetComponent<XRGrabInteractable>();
        _rigidbody = GetComponent<Rigidbody>();
        SetupWeaponEvents();
    }

    private void SetupWeaponEvents()
    {
        weaponInteractable.selectEntered.AddListener(PickupWeapon);
        weaponInteractable.selectExited.AddListener(DropWeapon);
        weaponInteractable.activated.AddListener(StartShooting);
        weaponInteractable.deactivated.AddListener(StopShooting);
    }

    private void OnDisable()
    {
        weaponInteractable.selectEntered.RemoveListener(PickupWeapon);
        weaponInteractable.selectExited.RemoveListener(DropWeapon);
        weaponInteractable.activated.RemoveListener(StartShooting);
        weaponInteractable.deactivated.RemoveListener(StopShooting);
    }

    protected virtual void StopShooting(DeactivateEventArgs args)
    {
        
    }

    protected virtual void StartShooting(ActivateEventArgs args)
    {
        
    }

    protected virtual void PickupWeapon(SelectEnterEventArgs args)
    {
        
    }
    protected virtual void DropWeapon(SelectExitEventArgs args)
    {
        
    }

    protected virtual void Shoot()
    {
        ApplyRecoil();
    }

    private void ApplyRecoil()
    {
        
    }
    
    
}
