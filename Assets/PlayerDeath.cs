using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    /// <summary>
    /// Attaching the UI to script
    /// </summary>
    public GameObject playerDeathUI;

    /// <summary>
    /// Disabling the Death UI when game starts
    /// </summary>
    private void Start()
    {
        playerDeathUI.SetActive(false);
    }

    /// <summary>
    /// Display UI upon death
    /// </summary>
    public void DeathUI()
    {
        playerDeathUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    /// <summary>
    /// Restarts player at start of level
    /// </summary>
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        playerDeathUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameManager.instance.ResetHealthBar();
        Time.timeScale = 1f;
    }

    /// <summary>
    /// Function to return player to menu
    /// </summary>
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("StartMenu");
        playerDeathUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
