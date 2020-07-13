using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyManager : MonoBehaviour
{

    [SerializeField] public int HoneyGathered = 100;
    public int TotalHoneyGathered = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHoneyCount();
    }

    public void AddHoneyToScore(int HoneyFromHex)
    {
        HoneyGathered += HoneyFromHex;
        TotalHoneyGathered += HoneyFromHex; //Use for determining final score

    }

    private void UpdateHoneyCount()
    {
        honeyMeter HoneyMeter = FindObjectOfType<honeyMeter>();
        HoneyMeter.GetComponent<TextMesh>().text = HoneyGathered.ToString();
    }
}
