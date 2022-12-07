using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public Button resumeButton;
    public Button optionsButton;
    public Button quitButton;
    public Button backButton;
    public Color originalColor;

    public static bool isPaused;

    void Start()
    {
        pauseMenu.SetActive(false);
        originalColor = resumeButton.GetComponent<Image>().color;
    }

    void Update()
    {
        if (!SceneTransition.isTransitioning)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused)
                {
                    ResumeGame();
                    resumeButton.GetComponent<Image>().color = originalColor;
                    optionsButton.GetComponent<Image>().color = originalColor;
                    quitButton.GetComponent<Image>().color = originalColor;
                    backButton.GetComponent<Image>().color = originalColor;
                }
                else
                {
                    PauseGame();
                }
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
