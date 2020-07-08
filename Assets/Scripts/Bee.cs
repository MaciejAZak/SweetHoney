using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{

    [SerializeField] int honeyOnBee = 0;
    [SerializeField] int BeeSpeed = 10;
    [SerializeField] float CollectingTime = 3f;
    GameObject myHex;
    GameObject myOldHex;
    string myHexName;

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
        if (honeyOnBee == 0)
        {
            GoToFlower();
        }
        else
        {
            GoToMyHex();
        }
    }

    private void GoToFlower()
    {
        var destiny = FindObjectOfType<flower>();
        Vector2 destinypath = new Vector2(destiny.transform.position.x - this.transform.position.x, destiny.transform.position.y - this.transform.position.y);
        //Debug.Log(this.name + " going to " + destiny.name + " " + destinypath);
        Vector2 destinyTransform = new Vector2(destiny.transform.position.x, destiny.transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, destinyTransform, BeeSpeed * Time.deltaTime);
        
    }

    private void CollectNectar()
    {
        StartCoroutine(WaitToGatherNectar());
    }

    IEnumerator WaitToGatherNectar()
    {
        Debug.Log("Started gathering nectar");
        GetComponent<AudioSource>().enabled = false;
        yield return new WaitForSeconds(CollectingTime);
        honeyOnBee = 1;
        FindMyNewHex();
        Debug.Log(myHex);
        GetComponent<AudioSource>().enabled = true;
    }

    private void FindMyNewHex()
    {
        GenerateHexes hexgenerator = FindObjectOfType<GenerateHexes>();
        // Old solution selecting random hex:

        //int xMax = hexgenerator.GetComponent<GenerateHexes>().width;
        //int yMax = hexgenerator.GetComponent<GenerateHexes>().height;
        //int x = Random.Range(0, xMax);
        //int y = Random.Range(0, yMax);
        //myHexName = "Hex_" + x + "_" + y;
        //myHex = GameObject.Find(myHexName);
        //Debug.Log(myHex.name);

        // New solution selecting one of the active hexes:

        if (myHex == null)
        {
            myHex = hexgenerator.ActiveHexes[Random.Range(0,hexgenerator.ActiveHexes.Count)];
        }
        else
        {
            myOldHex = myHex;
            myHex = hexgenerator.ActiveHexes[Random.Range(0, hexgenerator.ActiveHexes.Count)];
            if (myHex == myOldHex)
            {
                FindMyNewHex();
            }
        }
        //Debug.Log(myHex.name);
    }

    private void GoToMyHex()
    {
        var destiny = myHex;
        Vector2 destinypath = new Vector2(destiny.transform.position.x - this.transform.position.x, destiny.transform.position.y - this.transform.position.y);
        //Debug.Log(this.name + " going to " + destiny.name + " " + destinypath);
        Vector2 destinyTransform = new Vector2(destiny.transform.position.x, destiny.transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, destinyTransform, BeeSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        //Debug.Log(otherObject);
        if (otherObject.GetComponent<flower>() && honeyOnBee == 0)
        {
            CollectNectar();
            Debug.Log(this.name + " is collecting nectar");
        }
        else if (otherObject.name == myHex.name && honeyOnBee == 1)
        {
            Debug.Log("I'm at my hex");
            StartCoroutine(OffloadingNectarAtMyHex());

        }
    }

    IEnumerator OffloadingNectarAtMyHex()
    {

        GetComponent<AudioSource>().enabled = false;
        yield return new WaitForSeconds(CollectingTime);
        GetComponent<AudioSource>().enabled = true;

        if (myHex.GetComponent<honeyHex>().status < 5)
        {
            myHex.GetComponent<honeyHex>().status += 1;
            honeyOnBee = 0;
        }
        else if(myHex.GetComponent<honeyHex>().status == 5)
        {
            myHex.GetComponent<honeyHex>().status += 1;
            myHex.GetComponent<honeyHex>().FullHoney = true;
            honeyOnBee = 0;
        }
        else if (myHex.GetComponent<honeyHex>().status == 6)
        {
            myHex.GetComponent<honeyHex>().FullHoney = true;
            FindMyNewHex();
        }
    }
}
