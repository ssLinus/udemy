using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}