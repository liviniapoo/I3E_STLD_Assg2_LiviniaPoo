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
    public GameObject playerPrefab;
    private GameObject playerInstance;

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
        Destroy(playerInstance);
        playerDeathUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        ResetHealthBar();
        Time.timeScale = 1f;
        SpawnPlayer();
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

    private void ResetHealthBar()
    {
        GameManager.instance.healthBar.SetPlayerMaxHealth(Player.playerMaxHealth);
        GameManager.instance.healthBar.SetPlayerHealth(Player.playerHealth);
    }

    private void SpawnPlayer()
    {
        playerInstance  = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
    }
}
