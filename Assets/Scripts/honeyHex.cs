﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class honeyHex : MonoBehaviour
{

    [SerializeField] public int status;
    SpriteRenderer MySprite;
    Animator MyAnimator;
    [SerializeField] bool FullHoney = false;
    [SerializeField] bool ActiveHex = false;
    [SerializeField] bool CurrentlyGatheringHoney = false;

    // Start is called before the first frame update
    void Start()
    {
        MySprite = GetComponentInChildren<SpriteRenderer>();
        MyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        FillHexWithHoney();
        HexClicked();
    }

    void FillHexWithHoney()
    {
        {
            MyAnimator.SetInteger("status", status);
        }

    
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
         if (otherObject.GetComponent<Bee>() && status >= 1)
         {
            AddHoneyToHex();
         }
        
    }
    private void HexClicked()
    {
        if (Input.GetMouseButtonDown(0) && ActiveHex)
        {
            Debug.Log(this.name + " was left clicked.");
            if (FullHoney == true && !CurrentlyGatheringHoney)
            {
                CurrentlyGatheringHoney = true;
                StartCoroutine(WaitToGatherHoney());
            }
            else
            {
                AddHoneyToHex();
            }
        }
        else if (Input.GetMouseButtonDown(1) && ActiveHex)
        {
            Debug.Log(this.name + " was right clicked.");
            status -= 1;
        }
    }

    private void OnMouseOver()
    {
        // Debug.Log("mouse over " + this.name);
        ActiveHex = true;
    }
    private void OnMouseExit()
    {
        ActiveHex = false;
    }

    public void AddHoneyToHex()
    {
        if (status >=1)
        {
            if (status <= 4)
                status += 1;
            else if (status == 5)
            {
                status += 1;
                FullHoney = true;
            }
            else if (status == 6)
            {
                return;
            }
        }
    }

    IEnumerator WaitToGatherHoney()
    {
        Debug.Log("Started gathering honey...");

        yield return new WaitForSeconds(status - 1);
        status = 1;
        FullHoney = false;
        CurrentlyGatheringHoney = false;
        HoneyManager honeyManager = FindObjectOfType<HoneyManager>();
        honeyManager.AddHoneyToScore(5);
    }
}
