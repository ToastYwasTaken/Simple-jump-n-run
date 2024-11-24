using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Settings : MonoBehaviour
{

    static Settings settings;

    /// <summary>
    /// Instantiates a new Settings object if none in scene
    /// </summary>
    private void Awake()
    {
        if (settings == null)
        {
            settings = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Save current volume selected in slider to Prefs, to be able to load it in other scenes
    /// </summary>
    public void saveVolume()
    {
        Debug.Log("Audiolistener volume: " + AudioListener.volume);
        PlayerPrefs.SetFloat("volume", AudioListener.volume);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// get current volume in float
    /// range 0.0f - 1.0f
    /// </summary>
    /// <returns>volume</returns>
    public float getVolume()
    {
        return PlayerPrefs.GetFloat("volume");
    }

}
