using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public float speed = -10;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(speed, 2, 0);
    }

    void Update()
    {
        if (transform.position.y < -7)
        {
            Destroy(gameObject);
        }
    }
}