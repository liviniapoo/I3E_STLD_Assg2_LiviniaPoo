using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleTele : MonoBehaviour
{
    public GameObject teleMesh;

    void Start()
    {
        teleMesh.SetActive(false);
    }

    void Update()
    {
        if (Player.essenceCollected == true)
        {
            teleMesh.SetActive(true);
        }
    }
}
