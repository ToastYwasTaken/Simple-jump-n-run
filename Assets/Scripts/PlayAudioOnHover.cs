using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Plays audio when hovering over UI buttons
/// </summary>
public class PlayAudioOnHover : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnMouseEnter()
    {
        source.PlayOneShot(clip);
    }
    
}
