using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool bGameIsPaused;
    public GameObject PauseInterface;

    void Update()
    {
        OnKeyStroke();

        if (bGameIsPaused)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }

    void OnKeyStroke()
    {
        // Pauses the game
        if (Input.GetKeyDown(KeyCode.P))
        {
            bGameIsPaused = !bGameIsPaused;
        }
    }

    void Pause()
    {
        Time.timeScale = 0;
        //PauseInterface.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Resume()
    {
        Time.timeScale = 1;
        //PauseInterface.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
    }
}
