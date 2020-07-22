using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] public GameObject menus;

    public bool menuActive = false;
    GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.Find("MenuScreen");
        menu.SetActive(true); // Must be set to false, even though it's always true after first use - it its true from the start it does not work.
        menus.GetComponent<CanvasGroup>().alpha = 0;
        menus.GetComponent<CanvasGroup>().interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(menu.name);
        if (Input.GetKeyDown("escape") && menuActive == false)
        {
            ActivateMenu();
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown("escape") && menuActive == true)
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
    }

    public void DeactivateMenu()
    {
        menuActive = false;
        menu.SetActive(true);
        menus.GetComponent<CanvasGroup>().alpha = 0;
        menus.GetComponent<CanvasGroup>().interactable = false;
    }
}
