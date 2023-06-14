using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer; // Reference to MainMixer
    public Slider slider; // Reference to VolumeSlider
    public Dropdown resolutionDropdown; // Reference to resolution options
    public TMP_Dropdown qualityDropdown; // Refrence to quality options

    Resolution[] resolutions; // List of resolutions

    void Start()
    {
        qualityDropdown.value = QualitySettings.GetQualityLevel(); // Setting quality text to current quality
        float x;
        audioMixer.GetFloat("volume", out x); // Setting slider's value to current volume
        slider.value = x;
        resolutions = Screen.resolutions; // Getting avaible resolutions

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        // Loading avaible resolution to resolution dropdown options
        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        // Refreshing resolution options list
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }

    // Changing resolution
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

    }

    // Changing volume
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    // Changing quality
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    // Enabling/Disabling fullscreen
    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}