using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuScript : MonoBehaviour
{
    [SerializeField] GameObject BeeTaskToFillText;
    [SerializeField] GameObject HexTaskToFillText;
    [SerializeField] GameObject HoneyTaskToFillText;
    [SerializeField] GameObject BeeKeeperTaskToFillText;
    public bool BriefingActive;
    private Wipage screenWipe;
    private MenuManager menumanager;
    int currentSceneIndex;
    GameObject briefing;
    WinLoseConditions taskToFill;


    private void Awake()
    {
        screenWipe = FindObjectOfType<Wipage>();
        menumanager = FindObjectOfType<MenuManager>();
        taskToFill = FindObjectOfType<WinLoseConditions>();
        BriefingActive = true;
        BeeTaskToFillText.GetComponent<TextMeshProUGUI>().text = taskToFill.EndnumberOfBees.ToString();
        HexTaskToFillText.GetComponent<TextMeshProUGUI>().text = taskToFill.EndHexes.ToString();
        HoneyTaskToFillText.GetComponent<TextMeshProUGUI>().text = taskToFill.EndHoneyGathered.ToString();
        BeeKeeperTaskToFillText.GetComponent<TextMeshProUGUI>().text = taskToFill.EndBeeKeeperScore.ToString();
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
