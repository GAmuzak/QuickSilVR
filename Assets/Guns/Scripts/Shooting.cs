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
    private bool canShoot=true;

    private void Start()
    {
        gunRecoil = transform.GetChild(0).GetComponent<GunRecoil>();
    }

    public void Shoot()
    {
        if (!canShoot) return;
        Debug.Log("shooting!");
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        gunRecoil.Recoil();
        canShoot = false;
        StartCoroutine(FireRateController());
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
        yield return new WaitForSeconds(0.2f);
        canShoot = true;
    }
}
