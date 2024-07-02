/*
 * Author: Livinia Poo
 * Date: 01/07/2024
 * Description: 
 * Managing Main Menu buttons functionality
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Function to start game
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
