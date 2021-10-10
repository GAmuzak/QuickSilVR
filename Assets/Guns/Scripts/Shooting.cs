using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public GameObject cube;

    // [SerializeField] private TYPE _type;

    private GunRecoil gunRecoil;
    private Ammo ammoSetup;
    private bool canShoot=true;

    private void Start()
    {
        gunRecoil = transform.GetChild(0).GetComponent<GunRecoil>();
        ammoSetup = GetComponent<Ammo>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (ammoSetup.ammo != 0)
        {
            if (!canShoot) return;
            //Debug.Log("shooting!");
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
            gunRecoil.Recoil();
            ammoSetup.Shoot();
            canShoot = false;
            StartCoroutine(FireRateController());
        }
    }

    private void Ray()
    {
        RaycastHit hit;
        if (Physics.Raycast(bulletPos.position, -transform.right, out hit))
        {
            Instantiate(cube, hit.point, Quaternion.identity);
        }
    }

    private IEnumerator FireRateController()
    {
        yield return new WaitForSeconds(0.1f);
        canShoot = true;
    }
}
