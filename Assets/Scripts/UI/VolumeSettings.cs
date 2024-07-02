/*
 * Author: Livinia Poo
 * Date: 02/07/2024
 * Description: 
 * Adjusting Volumes Sliders
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    /// <summary>
    /// Attaching respective mixers to sliders
    /// </summary>
    [SerializeField]
    private AudioMixer myMixer;
    [SerializeField]
    private Slider bgmSlider;
    [SerializeField]
    private Slider sfxSlider;

    /// <summary>
    /// Setting up preferred volume settings
    /// </summary>
    private void Start()
    {
        if(PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
    }

    /// <summary>
    /// Function to set background music volume
    /// </summary>
    public void SetMusicVolume()
    {
        float volume = bgmSlider.value;
        myMixer.SetFloat("Music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    /// <summary>
    /// Function to set SFX volume
    /// </summary>
    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    /// <summary>
    /// Sets music and sounds to player's last setting
    /// </summary>
    private void LoadVolume()
    {
        bgmSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");

        SetMusicVolume();
        SetSFXVolume();
    }
}
