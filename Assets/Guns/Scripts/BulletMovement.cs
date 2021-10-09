using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float bulletSpeed;

    Transform gun;

    private void Start()
    {
        gun = GameObject.FindGameObjectWithTag("Gun").transform;
    }

    private void Update()
    {
        transform.Translate(gun.right * -bulletSpeed * Time.deltaTime);
    }
}
