using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] protected float projectileForce;
    [SerializeField] protected float lifetime;
    private Rigidbody _rigidbody;
    

    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddRelativeForce(transform.forward * projectileForce);
        Destroy(gameObject, lifetime);
    }
}
