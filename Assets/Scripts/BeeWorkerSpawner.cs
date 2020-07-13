using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeWorkerSpawner : MonoBehaviour
{
    [SerializeField] public int BeeCost = 10;
    [SerializeField] GameObject Bee;
    public int x = 0;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnWorker();
        }
    }

    private void Update()
    {
        this.GetComponentInChildren<TextMesh>().text = BeeCost.ToString();
    }

    private void SpawnWorker()
    {
        HoneyManager honeyManager = FindObjectOfType<HoneyManager>();
        if (honeyManager.HoneyGathered >= BeeCost)
        {
            GameObject bee = FindObjectOfType<Bee>().gameObject;
            honeyManager.AddHoneyToScore(-BeeCost);
            GameObject BeeCopy = (GameObject)Instantiate(Bee, bee.transform.position, Quaternion.identity);
            x += 1;
            BeeCopy.name = "Bee_worker" + x;
            Destroy(bee, 0f);

        }
        else
        {
            Debug.Log("Not enough honey");
        }
    }
}
