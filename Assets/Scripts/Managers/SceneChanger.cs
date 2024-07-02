/*
 * Author: Livinia Poo
 * Date: 24/06/2024
 * Description: 
 * Managing Player moving between scenes
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    /// <summary>
    /// Inspector input for target scene
    /// </summary>
    [SerializeField]
    private int targetSceneIndex;

    /// <summary>
    /// Teleport player upon collision into particular object
    /// </summary>
    /// <param name="other"></param>
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            ChangeScene();
        }
    }

    /// <summary>
    /// Function to change between scenes
    /// </summary>
    public void ChangeScene()
    {
        SceneManager.LoadScene(targetSceneIndex);
    }
}
