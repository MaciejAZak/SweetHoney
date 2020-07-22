using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    //public string levelName;



    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Map");
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
