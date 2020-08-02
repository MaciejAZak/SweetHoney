using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public bool BriefingActive;
    private Wipage screenWipe;
    private MenuManager menumanager;
    int currentSceneIndex;
    GameObject briefing;



    private void Awake()
    {
        screenWipe = FindObjectOfType<Wipage>();
        menumanager = FindObjectOfType<MenuManager>();
        BriefingActive = true;
    }

    public void LoadSettings()
    {
        Debug.Log("Load Settings");
    }

    public void LoadMainMenu()
    {
        StartCoroutine(LoadMainMenuCoroutine());
    }

    public void RestartLevel()
    { 
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(RestartLevelCoroutine());
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void StartLevel()
    {
        briefing = GameObject.Find("Briefing");
        briefing.SetActive(false);
        BriefingActive = false;
        Time.timeScale = 1f;
    }

    IEnumerator RestartLevelCoroutine()
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

    IEnumerator LoadMainMenuCoroutine()
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
