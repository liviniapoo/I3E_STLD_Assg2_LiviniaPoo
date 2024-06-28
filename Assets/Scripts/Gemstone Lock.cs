using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemstoneLock : MonoBehaviour
{
    [SerializeField]
    public GameObject gemLock;
    public static bool gemPlaced = false;

    void Start()
    {
        gemLock.SetActive(false);
    }

    private void Update()
    {
        if (gemPlaced)
        {
            gemLock.SetActive(true);
        }
    }

    public void PlaceGem()
    {
        gemPlaced = true;
    }
}
