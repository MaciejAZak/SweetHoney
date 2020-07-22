using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    int currentSceneIndex;
    private Wipage screenWipe;
    private MenuManager menumanager;


    private void Awake()
    {
        screenWipe = FindObjectOfType<Wipage>();
        menumanager = FindObjectOfType<MenuManager>();
    }

    public void LoadSettings()
    {
        Debug.Log("Load Settings");
    }

    public void LoadMainMenu()
    {
        StartCoroutine(LoadMainMenuCorutine());
    }

    public void RestartLevel()
    { 
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(RestartLevelCorutine());
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    IEnumerator RestartLevelCorutine()
    {
        screenWipe.ToggleWipe(true);
        Time.timeScale = 1f;
        menumanager.DeactivateMenu();
        while (!screenWipe.isDone)
        {
            yield return null;
        }
        SceneManager.LoadScene(currentSceneIndex);
    }

    IEnumerator LoadMainMenuCorutine()
    {
        screenWipe.ToggleWipe(true);
        Time.timeScale = 1f;
        menumanager.DeactivateMenu();
        while (!screenWipe.isDone)
        {
            yield return null;
        }
        SceneManager.LoadScene("MainMenu");
    }
}
