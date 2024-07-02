/*
 * Author: Livinia Poo
 * Date: 25/06/2024
 * Description: 
 * Keeping game values, UI and progress through scenes
 */

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Declaring static GameManager
    /// </summary>
    public static GameManager instance;

    /// <summary>
    /// UI Controlled by Game Manager
    /// </summary>
    public PlayerDeath deathUI;
    public PauseMenu pauseMenu;
    public PlayerHealthBar healthBar;
    public UIInteractions uiInteractions;

    /// <summary>
    /// Keeps any gameobjects under the GameManager object while moving between scenes, destroys repeats
    /// </summary>
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != null && instance != this)
        {
            Destroy(gameObject);
        } 
    }

    /// <summary>
    /// Resetting Healthbar
    /// </summary>
    private void Start()
    {
        ResetHealthBar();
    }

    public void ResetHealthBar()
    {
        healthBar.SetPlayerMaxHealth(Player.playerMaxHealth);
        healthBar.SetPlayerHealth(Player.playerHealth);
    }  

    /// <summary>
    /// Shows Player Death screen
    /// </summary>
    public void ShowDeathUI()
    {
        deathUI.DeathUI();
    }

    /// <summary>
    /// Toggles game Pause Screen
    /// </summary>
    public void ShowPauseUI()
    {
        pauseMenu.PauseGame();
    }

    public void HidePauseUI()
    {
        pauseMenu.ResumeGame();
    }

    /// <summary>
    /// Updating Player Healthbar
    /// </summary>
    private void Update()
    {
        healthBar.SetPlayerHealth(Player.playerHealth);
    }
}
