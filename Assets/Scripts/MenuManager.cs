using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    bool menuActive = false;
    GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.Find("MenuScreen");
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(menu.name);
        if (Input.GetKeyDown("escape") && menuActive == false)
        {
            menuActive = true;
            Time.timeScale = 0;
            menu.SetActive(true);
        }
        else if (Input.GetKeyDown("escape") && menuActive == true)
        {
            menuActive = false;
            Time.timeScale = 1;
            menu.SetActive(false);
        }
    }
}
