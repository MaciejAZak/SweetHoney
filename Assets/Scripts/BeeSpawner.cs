using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeSpawner : MonoBehaviour
{

    [SerializeField] public int BeeCost = 10;
    [SerializeField] GameObject Bee;
    public Vector3 SpawnPlace = new Vector3(0f, 0f, 0f);
    public int x = 0;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MenuManager menuActive = FindObjectOfType<MenuManager>();
            if (menuActive.menuActive == false)
            {
                SpawnBee();
            }
        }
    }

    private void Update()
    {
        this.GetComponentInChildren<TextMesh>().text = BeeCost.ToString();
    }

    private void SpawnBee()
    {
        HoneyManager honeyManager = FindObjectOfType<HoneyManager>();
        if (honeyManager.HoneyGathered >= BeeCost)
        {
            honeyManager.AddHoneyToScore(-BeeCost);
            GameObject BeeCopy = (GameObject)Instantiate(Bee, SpawnPlace, Quaternion.identity);
            x += 1;
            BeeCopy.name = "Bee_" + x;
        }
        else
        {
            Debug.Log("Not enough honey");
        }
    }
}
