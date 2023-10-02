using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Base : MonoBehaviour
{
    private int hit = 0;
    public static int hitCount;

    void Start()
    {
        hitCount = hit;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                Destroy(gameObject);

                GameManager gameManager = FindObjectOfType<GameManager>();
                gameManager.LifeCheck();

                hitCount++;

                if (hitCount == 3)
                {
                    playerController.Die();
                }
            }
        }
        else if (other.tag == "Wall")
            Destroy(gameObject);
    }
}