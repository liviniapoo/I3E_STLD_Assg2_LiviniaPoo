using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemstoneLock : MonoBehaviour
{
    /// <summary>
    /// Variables to declare necessary assets for the lock
    /// </summary>
    [SerializeField]
    public GameObject gemLock;
    public static bool gemPlaced = false;

    ///<summary>
    /// Referencing Audio Clips for Effects
    /// </summary>
    public AudioSource sfxAudio;

    /// <summary>
    /// Disables the gem's mesh visibilty on start
    /// </summary>
    void Start()
    {
        gemLock.SetActive(false);
    }

    /// <summary>
    /// Enables the gem's mesh visibilty when placed
    /// </summary>
    private void Update()
    {
        if (gemPlaced)
        {
            gemLock.SetActive(true);
            /*sfxAudio.Play();*/
        }
    }

    /// <summary>
    /// Updates the state of the gem's placement
    /// </summary>
    public void PlaceGem()
    {
        gemPlaced = true;
    }
}
