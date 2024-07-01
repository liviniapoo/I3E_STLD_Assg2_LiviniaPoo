/*
 * Author: Livinia Poo
 * Date: 01/07/2024
 * Description: 
 * Keeping player through scenes
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameManager : MonoBehaviour
{
    public static PlayerGameManager instance;

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
        else if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }

    }
}
