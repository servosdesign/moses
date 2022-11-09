using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;
    bool paused = false;

    void Start()
    {
        pauseMenu.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused == true)
            {
                Time.timeScale = 1.0f;
                pauseMenu.gameObject.SetActive(false);
                paused = false;
            }
            else
            {
                Time.timeScale = 0.0f;
                pauseMenu.gameObject.SetActive(true);
                paused = true;
            }
        }
    }
    public void PauseToMenu()
    {
        Time.timeScale = 1.0f;
    }
}
