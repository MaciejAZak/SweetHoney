using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class honeyStolenScript : MonoBehaviour
{

    [SerializeField] public int BeekeeperScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStolenHoneyCount();
    }

    private void UpdateStolenHoneyCount()
    {
        this.GetComponent<TextMesh>().text = BeekeeperScore.ToString();
    }

    public void StealHoney(int amount)
    {
        BeekeeperScore += amount;
    }
}
