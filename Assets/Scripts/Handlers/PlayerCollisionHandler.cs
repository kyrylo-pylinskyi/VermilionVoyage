using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.CompareTag("Obstacle"))
        {
            DisablePlayer();
            AudioManager.Instance.PlayCollideSound();
        }
    }

    private void DisablePlayer()
    {
        PlayerController playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            playerController.enabled = false;
            GameManager.Instance.ReloadLevel();
        }
    }
}
