using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addHoneyButton : MonoBehaviour
{
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HoneyManager honeyManager = FindObjectOfType<HoneyManager>();
            honeyManager.AddHoneyToScore(100);
        }
    }

}
