using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Scenemanager to switch between the scenes
/// </summary>
public class SceneManagement : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        //Loads main menu when pressing escape
       if(SceneManager.GetActiveScene().buildIndex.Equals(2) 
            && Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            LoadMainMenu();
        } 
    }

    /// <summary>
    /// Loads the main menu
    /// </summary>
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    /// <summary>
    /// loads level @param
    /// </summary>
    /// <param name="_sceneID">ID of the scene you want to switch to</param>
    public void LoadLevel(int _sceneID)
    {
        FindObjectOfType<Settings>().saveVolume();
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(_sceneID);
    }
    /// <summary>
    /// Quits the game
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }

    

}
