/*
 * Author: Livinia Poo
 * Date: 30/06/2024
 * Description: 
 * Checks whether player can end game
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    /// <summary>
    /// UI to show when win
    /// </summary>
    public GameObject victoryScreen;
    
    /// <summary>
    /// Disabling the victory screen on awake
    /// </summary>
    private void Start()
    {
        victoryScreen.SetActive(false);
    }

    /// <summary>
    /// Function to enable victory screen and halt game environment
    /// </summary>
    public void Victory()
    {
        victoryScreen.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        DialogueManager.canShoot = false;
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

    /// <summary>
    /// Ends the game if certain condition is met
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (RepairShip.shipFixed)
            {
                Victory();
            }
        }
    }
}
