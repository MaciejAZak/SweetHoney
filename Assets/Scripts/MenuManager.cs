using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] public GameObject menus;

    public bool menuActive = false;
    GameObject menu;
    MenuScript Briefing;

    // Start is called before the first frame update

    private void Awake()
    {
        menu = GameObject.Find("MenuScreen");
        menu.SetActive(false);
    }

    void Start()
    {
        menu.SetActive(true); // Must be set to false, even though it's always true after first use - it its true from the start it does not work.
        menus.GetComponent<CanvasGroup>().alpha = 0;
        menus.GetComponent<CanvasGroup>().interactable = false;
        menu.GetComponent<Image>().enabled = false;
        Time.timeScale = 0f;
        Briefing = FindObjectOfType<MenuScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(menu.name);
        if (Input.GetKeyDown("escape") && menuActive == false && Briefing.BriefingActive == false)
        {
            ActivateMenu();
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown("escape") && menuActive == true && Briefing.BriefingActive == false)
        {
            DeactivateMenu();
            Time.timeScale = 1;
        }
    }

    public void ActivateMenu()
    {
        menuActive = true;
        menu.SetActive(true);
        menus.GetComponent<CanvasGroup>().alpha = 1;
        menus.GetComponent<CanvasGroup>().interactable = true;
        menu.GetComponent<Image>().enabled = true;
    }

    public void DeactivateMenu()
    {
        menuActive = false;
        menu.SetActive(true);
        menus.GetComponent<CanvasGroup>().alpha = 0;
        menus.GetComponent<CanvasGroup>().interactable = false;
        menu.GetComponent<Image>().enabled = false;
    }
}
