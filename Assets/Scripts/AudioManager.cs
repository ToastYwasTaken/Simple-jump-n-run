using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the behaviour when using the slider concerning the volume
/// </summary>
public class AudioManager : MonoBehaviour
{
    public Slider slider;
    [Range(0.0f, 1.0f)]
    [SerializeField]
    public float volume = 1f;
    /// <summary>
    /// change volume when using the volume-slider in options scene
    /// </summary>
    public void changeVolume()
    {
        Debug.Log("slider value: " + slider.value);
        AudioListener.volume = slider.value;
    }

}
