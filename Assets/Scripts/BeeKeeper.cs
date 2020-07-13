using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeKeeper : MonoBehaviour
{
    [SerializeField] float BeeKeeperTime = 60f;
    [SerializeField] float startingTime = 15f;
    [SerializeField] AudioClip BeeKeeperLaugh;
    public float timeLeft;
    public int timeLeftInt;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("TakeAwayHoney", startingTime, BeeKeeperTime);
        timeLeft = startingTime + BeeKeeperTime;
    }

    // Update is called once per frame
    void Update()
    {

        timeLeft = timeLeft - Time.deltaTime;
        timeLeftInt = (int)timeLeft;
        this.GetComponentInChildren<TextMesh>().text = timeLeftInt.ToString();
    }

    IEnumerator BeekeeperGathersHoney()
    {
        Debug.Log("Start Time");
        yield return new WaitForSeconds(BeeKeeperTime);
        timeLeft = BeeKeeperTime;
        Debug.Log("Stop Time");
        AudioSource.PlayClipAtPoint(BeeKeeperLaugh, FindObjectOfType<Camera>().transform.position);
        GenerateHexes hexBuilderObject = FindObjectOfType<GenerateHexes>(); // find HeXBuilder where hexes are generated
        List<GameObject> activeHexesList = hexBuilderObject.ActiveHexes; // find list of active hexes
        List<GameObject> gatheredHexesList = hexBuilderObject.ToGatherHexes; // find list of active hexes

        int len = activeHexesList.Count; // count = 1   [0]
        
        for (int i = 0; i < len; i++)
        {
            activeHexesList[i].GetComponent<honeyHex>().ResetHexStatus();
        }
        int len2 = gatheredHexesList.Count; // count = 1   [0]

        for (int i = 0; i <= len2 -1; i++)
        {
            Debug.Log("list count is: " + gatheredHexesList.Count);
            Debug.Log("current i is: " + i);
            gatheredHexesList[i].GetComponent<honeyHex>().ResetHexStatus();
            gatheredHexesList[i].GetComponent<honeyHex>().CurrentlyGatheringHoney = false;
            activeHexesList.Add(gatheredHexesList[i]);
            gatheredHexesList.Remove(gatheredHexesList[i]);
            i -= 1;
        }

       // for (int i = 0; i <= len2 - 1; i++)
       // {
       //     Debug.Log("list count is: " + gatheredHexesList.Count);
       //     Debug.Log("current i is: " + i);
       //     if (gatheredHexesList.Count > 0)
       //     {
       //         gatheredHexesList[i].GetComponent<honeyHex>().ResetHexStatus();
       //         gatheredHexesList[i].GetComponent<honeyHex>().CurrentlyGatheringHoney = false;
       //         activeHexesList.Add(gatheredHexesList[i]);
       //         gatheredHexesList.Remove(gatheredHexesList[i]);
       //     }
       //     i -= 1;
       // }
    }

    public void TakeAwayHoney()
    {
        StartCoroutine(BeekeeperGathersHoney());

    }


}
