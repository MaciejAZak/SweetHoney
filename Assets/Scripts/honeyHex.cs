using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class honeyHex : MonoBehaviour
{

    [SerializeField] public int status;
    SpriteRenderer MySprite;
    Animator MyAnimator;
    [SerializeField] public bool FullHoney = false;
    [SerializeField] bool ActiveHex = false;
    [SerializeField] bool CurrentlyGatheringHoney = false;
    int gatheringTime = 1;
    int hexCost = 50;

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
            //AddHoneyToHex();
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
                WaitToGatherHoney();
            }
            else if (status >=1)
            {
                //AddHoneyToHex();
                //TODO: set bee to work on this hex
            }
            else if (status == 0)
            {
                BuildNewHex();
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
            {
                status += 1;
            }

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


    public void BuildNewHex()
    {

        HoneyManager honeyManager = FindObjectOfType<HoneyManager>();
        GenerateHexes hexgenerator = FindObjectOfType<GenerateHexes>();
        if (honeyManager.HoneyGathered >= hexCost)
        {
            honeyManager.AddHoneyToScore(-hexCost);
            hexgenerator.ToBuildHexes.Add(this.gameObject);
            this.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        }
        else
        {
            Debug.Log("Not enough honey");
        }

    }

    public void WaitToGatherHoney()
    {
        HoneyManager honeyManager = FindObjectOfType<HoneyManager>();
        GenerateHexes hexgenerator = FindObjectOfType<GenerateHexes>();
        hexgenerator.ActiveHexes.Remove(this.gameObject);
        hexgenerator.ToGatherHexes.Add(this.gameObject);
        GetComponentInChildren<SpriteRenderer>().color = Color.gray;
        // honeyManager.AddHoneyToScore(status - 1);
        // status = 1;
        // FullHoney = false;
        // CurrentlyGatheringHoney = false;
        // GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }

    public void HexGathered()
    {
        HoneyManager honeyManager = FindObjectOfType<HoneyManager>();
        GenerateHexes hexgenerator = FindObjectOfType<GenerateHexes>();
        status = 1;
        hexgenerator.ToGatherHexes.Remove(this.gameObject);
        hexgenerator.ActiveHexes.Add(this.gameObject);
        FullHoney = false;
        CurrentlyGatheringHoney = false;
        GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }

    public void HexBuilt()
    {

        GenerateHexes hexgenerator = FindObjectOfType<GenerateHexes>();
        status = 1;
        hexgenerator.ToBuildHexes.Remove(this.gameObject);
        hexgenerator.ActiveHexes.Add(this.gameObject);
        this.GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }
}
