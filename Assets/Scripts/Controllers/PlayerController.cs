using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public bool SteeringEnabled = true;
    public float gyroSensitivity = 1f;

    private void FixedUpdate()
    {
        HandleMovement();
        HandleFall();
        HandleQuit();
    }

    private void HandleMovement()
    {
        playerRigidbody.AddForce(Vector3.forward * forwardForce * Time.fixedDeltaTime);

        if (SteeringEnabled && SystemInfo.supportsGyroscope && Input.gyro.enabled)
        {
            float horizontalAxis = Input.gyro.rotationRateUnbiased.y * gyroSensitivity;
            playerRigidbody.AddForce(Vector3.right * horizontalAxis * sidewaysForce * Time.fixedDeltaTime);
        }
        else
        {
            float horizontalAxis = Input.GetAxis("Horizontal");
            playerRigidbody.AddForce(Vector3.right * horizontalAxis * sidewaysForce * Time.fixedDeltaTime);
        }
    }

    private void HandleFall()
    {
        if (playerRigidbody.transform.position.y < -1f)
        {
            DisablePlayer();
        }
    }

    private void DisablePlayer()
    {
        enabled = false;
        FindObjectOfType<GameManager>().ReloadLevel();
    }

    private void HandleQuit()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
