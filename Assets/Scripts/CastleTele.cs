using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleTele : MonoBehaviour
{
    /// <summary>
    /// Attaching the teleporter mesh
    /// </summary>
    public GameObject teleMesh;

    /// <summary>
    /// Disabling the mesh so it cannot be seen on start
    /// </summary>
    void Start()
    {
        teleMesh.SetActive(false);
    }

    /// <summary>
    /// Enables the mesh when condition has been fulfilled
    /// </summary>
    void Update()
    {
        if (Player.essenceCollected == true)
        {
            teleMesh.SetActive(true);
        }
    }
}
