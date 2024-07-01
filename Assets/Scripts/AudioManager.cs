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
    [Header("Audio Source")]
    [SerializeField]
    AudioSource bgmSource;
    /*[SerializeField]
    AudioSource sfxSource;*/

    [Header("Audio Clip")]
    public AudioClip background;

    private void Start()
    {
        bgmSource.clip = background;
        bgmSource.Play();
    }
}
