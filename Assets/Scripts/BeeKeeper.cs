﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeKeeper : MonoBehaviour
{
    [SerializeField] float BeeKeeperTime = 60f;

    // Start is called before the first frame update
    void Start()
    {
        TakeAwayHoney();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator BeekeeperGathersHoney()
    {
        Debug.Log("Start Time");
        yield return new WaitForSeconds(BeeKeeperTime);
        Debug.Log("Stop Time");
        GenerateHexes hexBuilderObject = FindObjectOfType<GenerateHexes>(); // find HeXBuilder where hexes are generated
        List<GameObject> activeHexesList = hexBuilderObject.ActiveHexes; // find list of active hexes

        int len = activeHexesList.Count; // count = 1   [0]
        
        for (int i = 0; i < len; i++)
        {
            activeHexesList[i].GetComponent<honeyHex>().ResetHexStatus();
        }
    }

    public void TakeAwayHoney()
    {
        StartCoroutine(BeekeeperGathersHoney());

    }
}