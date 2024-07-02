/*
 * Author: Livinia Poo
 * Date: 01/07/2024
 * Description: 
 * Managing Pause Menu buttons functionality
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    /// <summary>
    /// Attaching Menu to script
    /// </summary>
    public GameObject pauseMenu;

    /// <summary>
    /// Variable to check whether scene is paused
    /// </summary>
    public static bool isPaused;

    /// <summary>
    /// Disabling Pause UI upon start
    /// </summary>
    void Start()
    {
        pauseMenu.SetActive(false);
        Debug.Log("Start called, pause inactive");
    }


    /// <summary>
    /// Function to pause game
    /// </summary>
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Debug.Log("Game paused");
    }

    /// <summary>
    /// Function to resume game
    /// </summary>
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Debug.Log("Game resumed");
    }

    /// <summary>
    /// Function to return player to menu
    /// </summary>
    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    }

    /// <summary>
    /// Function to quit game app
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("quit app!");
        Application.Quit();
    }
}
