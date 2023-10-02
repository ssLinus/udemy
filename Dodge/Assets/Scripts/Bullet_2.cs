using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_2 : Bullet_Base
{
    public float speed = 6f;
    private Rigidbody bulletRigidbody;

    private Transform target;

    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();

        Destroy(gameObject, 3f);
    }

    void Update()
    {
        if (GameManager.isGameover == false)
        {
            target = FindObjectOfType<PlayerController>().transform;
            transform.LookAt(target);
            bulletRigidbody.velocity = transform.forward * speed;
        }
    }
}