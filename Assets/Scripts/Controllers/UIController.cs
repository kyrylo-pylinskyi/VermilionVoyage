using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    public static UIController Instance { get; private set; }
    public TMP_Text scoreText;
    public GameObject compliteLevelPanel;
    public GameObject levelStartPanel;
    public TMP_Text levelNumText;
    public Transform playerTransform;
    public PlayerController playerController;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (!playerController.enabled) return; 
        scoreText.text = playerTransform.transform.position.z.ToString("0");
    }

    public void ShowLevelStartPanel()
    {
        levelStartPanel?.SetActive(true);
        levelNumText.text = $"LEVEL {GameManager.LevelNum}";
    }

    public void ShowLevelComplitePanel()
    {
        levelStartPanel?.SetActive(false);
        compliteLevelPanel?.SetActive(true);
    }

    public void HideLevelComplitePanel()
    {
        compliteLevelPanel?.SetActive(false);
    }
}
