using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeWorker : MonoBehaviour
{
    [SerializeField] int honeyOnBee = 0;
    [SerializeField] int BeeSpeed = 15;
    [SerializeField] float CollectingTime = 3f;
    [SerializeField] float BuildingTime = 10f;
    GameObject myHex;
    [SerializeField] string activity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        DesisionMaker();
    }

    private void DesisionMaker()
    {
        GenerateHexes hexgenerator = FindObjectOfType<GenerateHexes>();
        if (honeyOnBee > 0)
        {
            activity = "GoToWarehouse";
            GoToWarehouse();
        }
        else if (hexgenerator.ToBuildHexes.Count > 0)
        {
            Debug.Log("To build hexes not null" + hexgenerator.ToBuildHexes.Count);
            activity = "GoToHexToBuild";
            GoToHexToBuild();
        }
        else if (hexgenerator.ToGatherHexes.Count > 0)
        {
            //Debug.Log(hexgenerator.ToGatherHexes.Count);
            activity = "GoToHexToGather";
            GoToHexToGather();
        }
    }

    public void GoToWarehouse()
    {
        var destiny = FindObjectOfType<Warehouse>();
        Vector2 destinypath = new Vector2(destiny.transform.position.x - this.transform.position.x, destiny.transform.position.y - this.transform.position.y);
        //Debug.Log(this.name + " going to " + destiny.name + " " + destinypath);
        Vector2 destinyTransform = new Vector2(destiny.transform.position.x, destiny.transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, destinyTransform, BeeSpeed * Time.deltaTime);
    }

    public void GoToHexToBuild()
    {
        GenerateHexes hexgenerator = FindObjectOfType<GenerateHexes>();
        if (myHex == null)
        {
            myHex = hexgenerator.ToBuildHexes[Random.Range(0, hexgenerator.ToBuildHexes.Count)];
        }
        var destiny = myHex;
        Vector2 destinyTransform = new Vector2(destiny.transform.position.x, destiny.transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, destinyTransform, BeeSpeed * Time.deltaTime);
    }

    public void GoToHexToGather()
    {
        GenerateHexes hexgenerator = FindObjectOfType<GenerateHexes>();
        if (myHex == null)
        {
            myHex = hexgenerator.ToGatherHexes[Random.Range(0, hexgenerator.ToGatherHexes.Count)];
        }
        var destiny = myHex;
        Vector2 destinyTransform = new Vector2(destiny.transform.position.x, destiny.transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, destinyTransform, BeeSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        Debug.Log(otherObject.name);
        if (myHex != null)
        {
            if (otherObject.name == myHex.name && activity == "GoToHexToBuild")
            {
                Debug.Log("I'm at my hex");
                StartCoroutine(BuildHex());
            }

            else if (otherObject.name == myHex.name && activity == "GoToHexToGather")
            {
                Debug.Log("I'm at my hex");
                StartCoroutine(GatherHex());
            }
        }

        if (otherObject.name == "Warehouse" && activity == "GoToWarehouse")
        {
            Debug.Log("I'm in warehouse");
            OffloadHoneyToWarehouse();
        }
    }

    IEnumerator BuildHex()
    {
        GetComponent<AudioSource>().enabled = false;
        yield return new WaitForSeconds(BuildingTime);
        GetComponent<AudioSource>().enabled = true;
        myHex.GetComponent<honeyHex>().HexBuilt();
        myHex = null;

    }

    IEnumerator GatherHex()
    {
        GetComponent<AudioSource>().enabled = false;
        yield return new WaitForSeconds(CollectingTime);
        GetComponent<AudioSource>().enabled = true;
        honeyOnBee = myHex.GetComponent<honeyHex>().status - 1;
        myHex.GetComponent<honeyHex>().HexGathered();
        myHex = null;
        
    }

    public void OffloadHoneyToWarehouse()
    {
        HoneyManager honeyManager = FindObjectOfType<HoneyManager>();
        honeyManager.AddHoneyToScore(honeyOnBee);
        honeyOnBee = 0;
    }

}
