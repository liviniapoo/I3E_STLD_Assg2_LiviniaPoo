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
    }

    /// <summary>
    /// Restarts player at start of level
    /// </summary>
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   
    }

    /// <summary>
    /// Function to return player to menu
    /// </summary>
    public void ReturnToMenu()
    {
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
