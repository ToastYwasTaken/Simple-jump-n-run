using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Loads the volume when loading a new scene
/// </summary>
public class LoadOnStart : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        AudioListener.volume = FindObjectOfType<Settings>().getVolume();
    }
}
