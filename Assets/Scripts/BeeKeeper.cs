using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeKeeper : MonoBehaviour
{
    [SerializeField] float BeeKeeperTime = 60f;
    [SerializeField] AudioClip BeeKeeperLaugh;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("TakeAwayHoney", 15f, BeeKeeperTime);
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

        for (int i = 0; i < len2 -1; i++)
        {
            gatheredHexesList[i].GetComponent<honeyHex>().ResetHexStatus();
            gatheredHexesList.Remove(gatheredHexesList[i]);
            activeHexesList.Add(gatheredHexesList[i]);
            Debug.Log(i);
            Debug.Log(gatheredHexesList.Count);
            i -= 1;
        }

    }

    public void TakeAwayHoney()
    {
        StartCoroutine(BeekeeperGathersHoney());

    }
}
