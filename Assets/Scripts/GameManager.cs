/*
 * Author: Livinia Poo
 * Date: 25/06/2024
 * Description: 
 * Keeping player values and progress through scenes
 */

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject teleMesh;
    public PlayerDeath deathUI;
    public PauseMenu pauseMenu;
    public PlayerHealthBar healthBar;

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
    /// Disabling tele on Start
    /// </summary>
    private void Start()
    {
        //deathUI = PlayerDeath.playerDeathUI;

        if (teleMesh != null)
        {
            teleMesh.SetActive(false);
            ResetHealthBar();
        }
    }

    public void ResetHealthBar()
    {
        healthBar.SetPlayerMaxHealth(Player.playerMaxHealth);
        healthBar.SetPlayerHealth(Player.playerHealth);
    }

    /// <summary>
    /// Function activates teleporter
    /// </summary>
    public void ActivateTeleMesh()
    {
        if (teleMesh != null)
        {
            teleMesh.SetActive (true);
        }
    }

    public void ShowDeathUI()
    {
        deathUI.DeathUI();
    }

    public void ShowPauseUI()
    {
        pauseMenu.PauseGame();
    }

    public void HidePauseUI()
    {
        pauseMenu.ResumeGame();
    }

    private void Update()
    {
        healthBar.SetPlayerHealth(Player.playerHealth);
    }
}
