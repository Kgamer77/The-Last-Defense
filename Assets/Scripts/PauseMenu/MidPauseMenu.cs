using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGamePauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;


    // Add the following code around the code in void update for MouseLook and RayShooter if they are the same from the class code
    // If not add it around the code that controls movement inputs, and the inputs for shooting
    // if (!PauseMenu.GameIsPaused)     or      if(Input.GetMouseButtonDown(0) && !PauseMenu.GameIsPaused)
    // {
    // }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (GameIsPaused)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                LoadMenu();
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                QuitGame();
            }
        }
    }

    public void Resume()
    {
        Debug.Log("Game is resumed");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        Debug.Log("Game is paused");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    public void LoadMenu()
    {
        // Unpauses the game
        Time.timeScale = 1f;
        // Swaps scenes to main menu
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        // Exits game application
        Debug.Log("Quitting Game ...");
        Application.Quit();
    }
}
