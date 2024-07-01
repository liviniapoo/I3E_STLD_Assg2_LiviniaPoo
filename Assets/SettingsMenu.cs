/*
 * Author: Livinia Poo
 * Date: 01/07/2024
 * Description: 
 * Giving slideres in settings menu functionality
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    /*/// <summary>
    /// Referencing Unity AudioMixer and Slider component
    /// </summary>
    public AudioMixer audioMixer;
    public Slider musicSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("BGMVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
        }
    }

    /// <summary>
    /// Adjusts the volume based on slider value
    /// </summary>
    /// <param name="volume"></param>
    public void SetMusicVolume(float volume)
    {
        musicSlider.value = volume;
        audioMixer.SetFloat("BGM Vol", volume);
        PlayerPrefs.SetFloat("BGMVolume", volume);
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("BGMVolume");
    }*/
}
