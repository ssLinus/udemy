using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float speed = -5;
    Player player;

    void Start()
    {
        player = GameObject.Find(name: "Player").GetComponent<Player>();
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);

        if (transform.position.x < -10)
        {
            Destroy(gameObject);
            player.addScore(1);
        }
    }
}