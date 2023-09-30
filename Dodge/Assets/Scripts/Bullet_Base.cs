using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Base : MonoBehaviour
{
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

                PlayerController.hitCount++;

                if (PlayerController.hitCount == 3)
                {
                    playerController.Die();
                }
            }
        }
        else if (other.tag == "Wall")
            Destroy(gameObject);
    }
}