﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeCounter : MonoBehaviour
{
    int numberOfBees;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBeeCount();
    }

    public void UpdateBeeCount()
    {
        numberOfBees = FindObjectsOfType<Bee>().Length;
        this.GetComponent<TextMesh>().text = numberOfBees.ToString();
    }
}
