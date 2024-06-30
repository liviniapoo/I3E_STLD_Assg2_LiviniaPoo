/*
 * Author: Livinia Poo
 * Date: 25/06/2024
 * Description: 
 * Keeping player values and progress through scenes
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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
}
