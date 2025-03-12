using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

// Just in case you need help with the setup, watch Brackey's Settings Menu in Unity video.

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider; // Reference to the slider
    

    void Start()
    {
        // Get the initial volume from the AudioMixer
        float volume = -80f;
        audioMixer.GetFloat("Master", out volume); 
        volumeSlider.value = volume; // Set the slider to the initial volume
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Master", volume);
    }

    // Update is called once per frame
    void Update()
    {
        // Check for arrow key presses and adjust the slider
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            volumeSlider.value -= 1f; // Decrease slider value
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            volumeSlider.value += 1f; // Increase slider value
        }

        // Clamp the value to ensure it stays within the slider's range
        volumeSlider.value = Mathf.Clamp(volumeSlider.value, volumeSlider.minValue, volumeSlider.maxValue);
    }
}

