using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Timer : MonoBehaviour
{

    float current_time = 0f;
    string secondsString;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        current_time = current_time + Time.deltaTime;
        int seconds = (int)current_time % 60;
        if (seconds <= 9)
        {
            if (seconds == 0)
            {
                secondsString = "00";
            }
            else if (seconds == 1)
            {
                secondsString = "01";
            }
            else if (seconds == 2)
            {
                secondsString = "02";
            }
            else if (seconds == 3)
            {
                secondsString = "03";
            }
            else if (seconds == 4)
            {
                secondsString = "04";
            }
            else if (seconds == 5)
            {
                secondsString = "05";
            }
            else if (seconds == 6)
            {
                secondsString = "06";
            }
            else if (seconds == 7)
            {
                secondsString = "07";
            }
            else if (seconds == 8)
            {
                secondsString = "08";
            }
            else if (seconds == 9)
            {
                secondsString = "09";
            }
        }
        else
        {
            secondsString = seconds.ToString();
        }
        int minutes = (int)current_time / 60;
        string display = "time: " + minutes.ToString() +  ":" + secondsString;
        this.GetComponent<TextMesh>().text = display;

    }
}
