using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }

    public float reloadLevelDelay = 3.0f;
    public float completeLevelDelay = 1.5f;
    public static int LevelNum { get; private set; } = 1;

    private bool gameEnded;

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

    private void Start()
    {
        UIController.Instance?.ShowLevelStartPanel();
    }

    public void CompleteLevel()
    {
        UIController.Instance.ShowLevelComplitePanel();
        LevelNum++;
        Invoke(nameof(ReloadScene), completeLevelDelay);
    }

    public void ReloadLevel()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            Invoke(nameof(ReloadScene), reloadLevelDelay);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        UIController.Instance?.HideLevelComplitePanel();
    }
}
