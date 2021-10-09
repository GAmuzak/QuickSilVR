using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float bulletSpeed;

    private void Update()
    {
        transform.Translate(transform.forward * bulletSpeed * Time.deltaTime);
    }
}
