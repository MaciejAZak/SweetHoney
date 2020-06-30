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
                StartCoroutine(WaitToGatherHoney());
            }
            else if (status >=1)
            {
                AddHoneyToHex();
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
        if(honeyManager.HoneyGathered >= hexCost)
        {
            honeyManager.AddHoneyToScore(-hexCost);
            status += 1;
        }
        else
        {
            Debug.Log("Not enough honey");
        }

    }

    IEnumerator WaitToGatherHoney()
    {
        Debug.Log("Started gathering honey...");
        GetComponentInChildren<SpriteRenderer>().color = Color.gray;
        yield return new WaitForSeconds(gatheringTime);
        HoneyManager honeyManager = FindObjectOfType<HoneyManager>();
        honeyManager.AddHoneyToScore(status - 1);
        status = 1;
        FullHoney = false;
        CurrentlyGatheringHoney = false;
        GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }
}
