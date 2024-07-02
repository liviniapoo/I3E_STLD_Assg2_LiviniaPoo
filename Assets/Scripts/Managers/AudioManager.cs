/*
 * Author: Livinia Poo
 * Date: 01/07/2024
 * Description: 
 * Managing BGM and SFX
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// Attaching Audio Sources and Clips
    /// </summary>
    [Header("Audio Source")]
    [SerializeField]
    AudioSource bgmSource;
    [Header("Audio Clip")]
    public AudioClip background;

    /// <summary>
    /// Plays assigned background music for scene
    /// </summary>
    private void Start()
    {
        bgmSource.clip = background;
        bgmSource.Play();
    }
}
