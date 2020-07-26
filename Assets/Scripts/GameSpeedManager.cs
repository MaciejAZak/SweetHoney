using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeedManager : MonoBehaviour
{
    [SerializeField] GameObject pause;
    [SerializeField] GameObject play;
    [SerializeField] GameObject speed2x;

    private void Awake()
    {


    }

    void Start()
    {
        //pause = this.transform.Find("PauseButton").gameObject;
        //play = this.transform.Find("PlayButton").gameObject;
        //speed2x = this.transform.Find("Speed2xButton").gameObject;
    }

    
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MenuManager menuActive = FindObjectOfType<MenuManager>();
            if (menuActive.menuActive == false)
            {
                print(this);
                if (this.name == "PauseButton")
                {
                    Time.timeScale = 0f;
                    GetComponentInChildren<SpriteRenderer>().color = Color.yellow;
                    play.GetComponentInChildren<SpriteRenderer>().color = Color.white;
                    speed2x.GetComponentInChildren<SpriteRenderer>().color = Color.white;

                }
                else if (this.name == "PlayButton")
                {
                    Time.timeScale = 1f;
                    GetComponentInChildren<SpriteRenderer>().color = Color.yellow;
                    pause.GetComponentInChildren<SpriteRenderer>().color = Color.white;
                    speed2x.GetComponentInChildren<SpriteRenderer>().color = Color.white;
                }
                else if (this.name == "Speed2xButton")
                {
                    Time.timeScale = 2f;
                    GetComponentInChildren<SpriteRenderer>().color = Color.yellow;
                    pause.GetComponentInChildren<SpriteRenderer>().color = Color.white;
                    play.GetComponentInChildren<SpriteRenderer>().color = Color.white;
                }
            }
            //Debug.Log(this.name);
        }
    }
}
